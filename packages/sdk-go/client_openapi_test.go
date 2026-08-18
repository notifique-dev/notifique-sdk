package notifique

import (
	"encoding/json"
	"net/http"
	"net/http/httptest"
	"strings"
	"testing"
)

func TestOperationRegistryHas353Operations(t *testing.T) {
	reg := defaultRegistry
	if reg.Count != 353 {
		t.Fatalf("expected count 353, got %d", reg.Count)
	}
	if len(reg.Operations) != 353 {
		t.Fatalf("expected 353 operations in slice, got %d", len(reg.Operations))
	}
	if len(reg.ByPath) != 353 {
		t.Fatalf("expected 353 operations in ByPath, got %d", len(reg.ByPath))
	}
	if len(reg.ByID) != 353 {
		t.Fatalf("expected 353 operations in ByID, got %d", len(reg.ByID))
	}
}

func TestAllOperationsReachableInRegistry(t *testing.T) {
	client, err := NewClientWithConfigSafe(Config{APIKey: "test-key"})
	if err != nil {
		t.Fatal(err)
	}
	api := client.DynamicAPI()

	for _, op := range defaultRegistry.Operations {
		path := operationPath(op.Namespaces, op.MethodName)
		if !api.Has(path) {
			t.Errorf("operation missing from registry: %s", path)
			continue
		}
		if got := api.GetOperation(path); got == nil || got.OperationID != op.OperationID {
			t.Errorf("GetOperation(%s) mismatch", path)
		}
		if _, ok := defaultRegistry.ByPath[path]; !ok {
			t.Errorf("ByPath missing %s", path)
		}
	}

	if missing := 353 - len(defaultRegistry.ByPath); missing != 0 {
		t.Errorf("registry incomplete: %d operations missing", missing)
	}
}

func TestNamespaceTreeExposesAllOperations(t *testing.T) {
	client, err := NewClientWithConfigSafe(Config{APIKey: "k"})
	if err != nil {
		t.Fatal(err)
	}
	api := client.DynamicAPI()

	seen := make(map[string]struct{}, 353)
	var walk func(node *namespaceNode, prefix []string)
	walk = func(node *namespaceNode, prefix []string) {
		for methodName := range node.methods {
			path := operationPath(prefix, methodName)
			seen[path] = struct{}{}
		}
		for childName, child := range node.children {
			walk(child, append(prefix, childName))
		}
	}
	walk(api.root, nil)

	for _, op := range defaultRegistry.Operations {
		path := operationPath(op.Namespaces, op.MethodName)
		if _, ok := seen[path]; !ok {
			t.Errorf("namespace tree missing operation %s", path)
		}
	}
	if len(seen) != 353 {
		t.Fatalf("namespace tree has %d operations, want 353", len(seen))
	}
}

func TestDynamicAPINavigateAndCall(t *testing.T) {
	var gotPath string
	server := httptest.NewServer(http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		gotPath = r.URL.Path
		w.WriteHeader(http.StatusOK)
		json.NewEncoder(w).Encode(map[string]any{"success": true})
	}))
	defer server.Close()

	client, err := NewClientWithConfigSafe(Config{
		APIKey:            "k",
		BaseURL:           server.URL,
		AllowInsecureHTTP: true,
	})
	if err != nil {
		t.Fatal(err)
	}

	api := client.DynamicAPI()
	_, err = api.Call("wellKnown.getJwks", DynamicRequestOptions{})
	if err != nil {
		t.Fatal(err)
	}
	if gotPath != "/.well-known/jwks.json" {
		t.Errorf("expected /.well-known/jwks.json, got %s", gotPath)
	}

	ns, err := api.Navigate("public", "aiWidget")
	if err != nil {
		t.Fatal(err)
	}
	if !ns.HasMethod("getConfig") {
		t.Fatal("expected getConfig method")
	}
	_, err = ns.Call("getConfig", DynamicRequestOptions{
		PathParams: map[string]string{"publicKey": "pk_test"},
	})
	if err != nil {
		t.Fatal(err)
	}
	if !strings.Contains(gotPath, "pk_test") {
		t.Errorf("path param not substituted: %s", gotPath)
	}
}

func TestDynamicAPIUsesHostBaseURLWithV1Paths(t *testing.T) {
	client, err := NewClientWithConfigSafe(Config{APIKey: "k"})
	if err != nil {
		t.Fatal(err)
	}
	if client.DynamicAPI().baseURL != "https://api.notifique.dev" {
		t.Errorf("expected host base URL, got %s", client.DynamicAPI().baseURL)
	}
	op := client.DynamicAPI().GetOperation("whatsapp.postV1WhatsappSend")
	if op == nil {
		t.Fatal("whatsapp.postV1WhatsappSend not found")
	}
	if op.Path != "/v1/whatsapp/messages" {
		t.Errorf("unexpected path: %s", op.Path)
	}
}

func TestNotifiqueAPIAccessor(t *testing.T) {
	client, err := NewClientWithConfigSafe(Config{APIKey: "k"})
	if err != nil {
		t.Fatal(err)
	}
	if client.API() == nil {
		t.Fatal("API() returned nil")
	}
	if client.Api != client.API() {
		t.Error("Api field should match API()")
	}
	if client.DynamicAPI() == nil {
		t.Fatal("DynamicAPI() returned nil")
	}
}
