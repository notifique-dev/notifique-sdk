package notifique

import (
	"bytes"
	_ "embed"
	"encoding/json"
	"fmt"
	"io"
	"net/http"
	"net/url"
	"strings"
)

//go:embed operations.json
var embeddedOperationsJSON []byte

// Operation describes one OpenAPI operation from the embedded registry.
type Operation struct {
	Spec         string   `json:"spec"`
	OperationID  string   `json:"operationId"`
	HTTPMethod   string   `json:"httpMethod"`
	Path         string   `json:"path"`
	URLTemplate  string   `json:"urlTemplate"`
	Namespaces   []string `json:"namespaces"`
	MethodName   string   `json:"methodName"`
	PathParams   []string `json:"pathParams"`
	RequiresAuth bool     `json:"requiresAuth"`
	Idempotent   bool     `json:"idempotent"`
	Summary      string   `json:"summary"`
}

type operationsFile struct {
	Count      int         `json:"count"`
	Operations []Operation `json:"operations"`
}

// OperationRegistry indexes all OpenAPI operations by dotted namespace path.
type OperationRegistry struct {
	Count      int
	Operations []*Operation
	ByPath     map[string]*Operation
	ByID       map[string]*Operation
}

// DynamicRequestOptions configures a dynamic API call.
type DynamicRequestOptions struct {
	PathParams     map[string]string
	Query          map[string]string
	Body           interface{}
	IdempotencyKey string
	Headers        map[string]string
}

// DynamicAPI exposes all OpenAPI operations via a namespace tree and Call.
// Base URL is the API host (https://api.notifique.dev); operation paths include /v1/... or /.well-known/...
type DynamicAPI struct {
	client   *Notifique
	baseURL  string
	registry *OperationRegistry
	root     *namespaceNode
}

// NamespaceView navigates nested API namespaces (e.g. oauth → apps).
type NamespaceView struct {
	api  *DynamicAPI
	node *namespaceNode
}

type namespaceNode struct {
	name     string
	children map[string]*namespaceNode
	methods  map[string]*Operation
}

var defaultRegistry = mustLoadOperationRegistry()

func mustLoadOperationRegistry() *OperationRegistry {
	var file operationsFile
	if err := json.Unmarshal(embeddedOperationsJSON, &file); err != nil {
		panic(fmt.Sprintf("notifique: parse operations.json: %v", err))
	}
	reg := &OperationRegistry{
		Count:      file.Count,
		Operations: make([]*Operation, 0, len(file.Operations)),
		ByPath:     make(map[string]*Operation, len(file.Operations)),
		ByID:       make(map[string]*Operation, len(file.Operations)),
	}
	for i := range file.Operations {
		op := file.Operations[i]
		reg.Operations = append(reg.Operations, &op)
		path := operationPath(op.Namespaces, op.MethodName)
		reg.ByPath[path] = &op
		idKey := op.OperationID
		if idKey == "" {
			idKey = op.HTTPMethod + " " + op.Path
		}
		reg.ByID[idKey] = &op
	}
	return reg
}

func operationPath(namespaces []string, methodName string) string {
	parts := append([]string{}, namespaces...)
	parts = append(parts, methodName)
	return strings.Join(parts, ".")
}

func dynamicAPIBaseURL(clientBase string) string {
	base := strings.TrimSuffix(strings.TrimSpace(clientBase), "/")
	if strings.HasSuffix(base, "/v1") {
		return strings.TrimSuffix(base, "/v1")
	}
	return base
}

func buildNamespaceTree(ops []*Operation) *namespaceNode {
	root := &namespaceNode{
		name:     "",
		children: make(map[string]*namespaceNode),
		methods:  make(map[string]*Operation),
	}
	for _, op := range ops {
		node := root
		for _, ns := range op.Namespaces {
			child, ok := node.children[ns]
			if !ok {
				child = &namespaceNode{
					name:     ns,
					children: make(map[string]*namespaceNode),
					methods:  make(map[string]*Operation),
				}
				node.children[ns] = child
			}
			node = child
		}
		node.methods[op.MethodName] = op
	}
	return root
}

func newDynamicAPI(client *Notifique, registry *OperationRegistry) *DynamicAPI {
	return &DynamicAPI{
		client:   client,
		baseURL:  dynamicAPIBaseURL(client.BaseURL),
		registry: registry,
		root:     buildNamespaceTree(registry.Operations),
	}
}

// Registry returns the embedded operation registry.
func (d *DynamicAPI) Registry() *OperationRegistry {
	return d.registry
}

// OperationCount returns the number of registered operations.
func (d *DynamicAPI) OperationCount() int {
	return d.registry.Count
}

// Has returns whether an operation exists at the dotted path (e.g. "whatsapp.send").
func (d *DynamicAPI) Has(dottedPath string) bool {
	_, ok := d.registry.ByPath[dottedPath]
	return ok
}

// GetOperation returns the operation for a dotted path, or nil.
func (d *DynamicAPI) GetOperation(dottedPath string) *Operation {
	return d.registry.ByPath[dottedPath]
}

// Namespace returns a view into a top-level namespace (e.g. "whatsapp", "oauth").
func (d *DynamicAPI) Namespace(name string) (*NamespaceView, error) {
	return d.Navigate(name)
}

// Navigate walks the namespace tree (e.g. "oauth", "apps").
func (d *DynamicAPI) Navigate(namespaces ...string) (*NamespaceView, error) {
	node := d.root
	for _, ns := range namespaces {
		child, ok := node.children[ns]
		if !ok {
			return nil, fmt.Errorf("notifique: unknown namespace %q", ns)
		}
		node = child
	}
	return &NamespaceView{api: d, node: node}, nil
}

// Call executes an operation by dotted path (e.g. "whatsapp.send", "public.aiWidget.getConfig").
func (d *DynamicAPI) Call(dottedPath string, opts DynamicRequestOptions) (json.RawMessage, error) {
	op, ok := d.registry.ByPath[dottedPath]
	if !ok {
		return nil, fmt.Errorf("notifique: unknown operation %q", dottedPath)
	}
	return d.invoke(op, opts)
}

// Child returns a nested namespace.
func (v *NamespaceView) Child(name string) (*NamespaceView, error) {
	child, ok := v.node.children[name]
	if !ok {
		return nil, fmt.Errorf("notifique: unknown namespace %q", name)
	}
	return &NamespaceView{api: v.api, node: child}, nil
}

// HasMethod reports whether the namespace exposes methodName.
func (v *NamespaceView) HasMethod(methodName string) bool {
	_, ok := v.node.methods[methodName]
	return ok
}

// Methods returns method names available at this namespace.
func (v *NamespaceView) Methods() []string {
	out := make([]string, 0, len(v.node.methods))
	for name := range v.node.methods {
		out = append(out, name)
	}
	return out
}

// Children returns child namespace names.
func (v *NamespaceView) Children() []string {
	out := make([]string, 0, len(v.node.children))
	for name := range v.node.children {
		out = append(out, name)
	}
	return out
}

// Call invokes a method on the current namespace.
func (v *NamespaceView) Call(methodName string, opts DynamicRequestOptions) (json.RawMessage, error) {
	op, ok := v.node.methods[methodName]
	if !ok {
		return nil, fmt.Errorf("notifique: unknown method %q in namespace", methodName)
	}
	return v.api.invoke(op, opts)
}

func (d *DynamicAPI) invoke(op *Operation, opts DynamicRequestOptions) (json.RawMessage, error) {
	path, err := buildOperationURL(op.URLTemplate, opts.PathParams)
	if err != nil {
		return nil, err
	}
	if len(opts.Query) > 0 {
		q := url.Values{}
		for k, v := range opts.Query {
			q.Set(k, v)
		}
		path = path + "?" + q.Encode()
	}

	reqURL := d.baseURL + path
	var bodyReader io.Reader
	if opts.Body != nil {
		buf := new(bytes.Buffer)
		if err := json.NewEncoder(buf).Encode(opts.Body); err != nil {
			return nil, err
		}
		bodyReader = buf
	}

	req, err := http.NewRequest(op.HTTPMethod, reqURL, bodyReader)
	if err != nil {
		return nil, err
	}
	if op.RequiresAuth && d.client.APIKey != "" {
		req.Header.Set("Authorization", "Bearer "+d.client.APIKey)
	}
	req.Header.Set("Content-Type", "application/json")
	req.Header.Set("User-Agent", "Notifique-Go-SDK/0.2.0")
	for k, v := range opts.Headers {
		if v != "" {
			req.Header.Set(k, v)
		}
	}
	if opts.IdempotencyKey != "" {
		req.Header.Set("Idempotency-Key", opts.IdempotencyKey)
		req.Header.Set("x-idempotency-key", opts.IdempotencyKey)
	}

	resp, err := d.client.HTTPClient.Do(req)
	if err != nil {
		return nil, err
	}
	defer resp.Body.Close()

	bodyBytes, err := io.ReadAll(resp.Body)
	if err != nil {
		return nil, err
	}
	if resp.StatusCode >= 400 {
		return nil, &APIError{Code: resp.StatusCode, Body: string(bodyBytes)}
	}
	return json.RawMessage(bodyBytes), nil
}

func buildOperationURL(template string, pathParams map[string]string) (string, error) {
	if len(pathParams) == 0 && !strings.Contains(template, "{") {
		return template, nil
	}
	result := template
	for _, segment := range strings.Split(template, "/") {
		if !strings.HasPrefix(segment, "{") || !strings.HasSuffix(segment, "}") {
			continue
		}
		param := strings.TrimSuffix(strings.TrimPrefix(segment, "{"), "}")
		val, ok := pathParams[param]
		if !ok {
			return "", fmt.Errorf("notifique: missing path param %q", param)
		}
		result = strings.Replace(result, "{"+param+"}", url.PathEscape(val), 1)
	}
	return result, nil
}
