<?php

namespace Notifique;

use GuzzleHttp\Client as GuzzleClient;
use GuzzleHttp\Exception\GuzzleException;
use Notifique\Exception\NotifiqueApiException;
use Notifique\Generated\TypedGeneratedApi;
use Notifique\Generated\DynamicApi;
use Notifique\Generated\ApiNamespace;

/**
 * Cliente Notifique — WhatsApp, SMS, Email, Push e envio por template.
 * Em 4xx/5xx lança NotifiqueApiException.
 */
class Notifique
{
    private string $apiKey;
    private string $baseUrl;
    private GuzzleClient $httpClient;

    public Whatsapp $whatsapp;
    public Sms $sms;
    public Email $email;
    public Messages $messages;
    public Push $push;

    /** Full generated API (353 operations) with typed namespaces. */
    public TypedGeneratedApi $api;

    /** @var array<string, ApiNamespace> */
    private array $dynamicNamespaces = [];

    public function __construct(string $apiKey, string $baseUrl = 'https://api.notifique.dev/v1', array $guzzleOptions = [])
    {
        if (trim($apiKey) === '') {
            throw new \InvalidArgumentException('apiKey must be a non-empty string.');
        }
        $parsed = parse_url($baseUrl);
        if (!is_array($parsed) || ($parsed['scheme'] ?? '') !== 'https' || empty($parsed['host'])) {
            throw new \InvalidArgumentException('baseUrl must be an absolute HTTPS URL.');
        }
        $this->apiKey = $apiKey;
        $this->baseUrl = rtrim($baseUrl, '/');

        $defaultOptions = [
            'base_uri' => $this->baseUrl . '/',
            'timeout' => 30.0,
            'headers' => [
                'Authorization' => "Bearer {$this->apiKey}",
                'Content-Type' => 'application/json',
                'User-Agent' => 'Notifique-PHP-SDK/0.2.0',
            ],
        ];

        $this->httpClient = new GuzzleClient(array_merge($defaultOptions, $guzzleOptions));
        $this->whatsapp = new Whatsapp($this);
        $this->sms = new Sms($this);
        $this->email = new Email($this);
        $this->messages = new Messages($this);
        $this->push = new Push($this);
        $this->api = new TypedGeneratedApi($this);
        DynamicApi::attachNamespaces($this);
    }

    public function __get(string $name): ApiNamespace
    {
        if (!isset($this->dynamicNamespaces[$name])) {
            $this->dynamicNamespaces[$name] = new ApiNamespace($this, [$name]);
        }

        return $this->dynamicNamespaces[$name];
    }

    public function attachDynamicNamespace(string $name): void
    {
        if (!isset($this->dynamicNamespaces[$name])) {
            $this->dynamicNamespaces[$name] = new ApiNamespace($this, [$name]);
        }
    }

    /**
     * Executa a requisição HTTP. Em status >= 400 lança NotifiqueApiException.
     * @param array $options Opcional: ['headers' => ['Idempotency-Key' => '...']] para idempotência.
     * @return array decoded JSON
     * @throws NotifiqueApiException
     */
    public function request(string $method, string $path, ?array $body = null, array $options = []): array
    {
        $path = ltrim($path, '/');
        $requestOptions = [];

        if ($body !== null && $body !== [] && !in_array($method, ['GET', 'DELETE'], true)) {
            $requestOptions['json'] = $body;
        }

        if (isset($options['headers']) && is_array($options['headers'])) {
            $requestOptions['headers'] = $options['headers'];
        }

        try {
            $response = $this->httpClient->request($method, $path, $requestOptions);
        } catch (GuzzleException $e) {
            $resp = $e->getResponse();
            $code = $resp ? $resp->getStatusCode() : 0;
            $bodyContent = $resp ? (string) $resp->getBody() : $e->getMessage();
            $message = $bodyContent;
            $decoded = json_decode($bodyContent, true);
            if (is_array($decoded) && isset($decoded['message']) && is_string($decoded['message'])) {
                $message = $decoded['message'];
                if (!empty($decoded['details']) && is_array($decoded['details'])) {
                    $parts = array_map(
                        fn(array $d) => trim((isset($d['field']) ? $d['field'] . ': ' : '') . ($d['message'] ?? '')),
                        $decoded['details']
                    );
                    $parts = array_filter($parts);
                    if ($parts !== []) {
                        $message .= ' (' . implode('; ', $parts) . ')';
                    }
                }
            }
            throw new NotifiqueApiException($code, $message, $e);
        }

        $contents = $response->getBody()->getContents();
        if ($contents === '') {
            return [];
        }

        $decoded = json_decode($contents, true);
        if (json_last_error() !== JSON_ERROR_NONE) {
            throw new NotifiqueApiException($response->getStatusCode(), $contents);
        }

        return $decoded;
    }

    /**
     * Executa requisição com path absoluto da OpenAPI (ex.: /v1/oauth/apps, /.well-known/jwks.json).
     *
     * @return array<string, mixed>
     * @throws NotifiqueApiException
     */
    public function apiRequest(string $method, string $path, ?array $body = null, array $options = []): array
    {
        $apiBase = preg_replace('#/v1/?$#', '', $this->baseUrl);
        $fullPath = str_starts_with($path, '/') ? $path : '/' . $path;
        $requestOptions = [];

        if ($body !== null && $body !== [] && !in_array($method, ['GET', 'DELETE'], true)) {
            $requestOptions['json'] = $body;
        }

        if (isset($options['headers']) && is_array($options['headers'])) {
            $requestOptions['headers'] = $options['headers'];
        }

        try {
            $response = $this->httpClient->request($method, $apiBase . $fullPath, $requestOptions);
        } catch (GuzzleException $e) {
            $resp = $e->getResponse();
            $code = $resp ? $resp->getStatusCode() : 0;
            $bodyContent = $resp ? (string) $resp->getBody() : $e->getMessage();
            $message = $bodyContent;
            $decoded = json_decode($bodyContent, true);
            if (is_array($decoded) && isset($decoded['message']) && is_string($decoded['message'])) {
                $message = $decoded['message'];
                if (!empty($decoded['details']) && is_array($decoded['details'])) {
                    $parts = array_map(
                        fn(array $d) => trim((isset($d['field']) ? $d['field'] . ': ' : '') . ($d['message'] ?? '')),
                        $decoded['details']
                    );
                    $parts = array_filter($parts);
                    if ($parts !== []) {
                        $message .= ' (' . implode('; ', $parts) . ')';
                    }
                }
            }
            throw new NotifiqueApiException($code, $message, $e);
        }

        $contents = $response->getBody()->getContents();
        if ($contents === '') {
            return [];
        }

        $decoded = json_decode($contents, true);
        if (json_last_error() !== JSON_ERROR_NONE) {
            throw new NotifiqueApiException($response->getStatusCode(), $contents);
        }

        return $decoded;
    }

    public static function encodePathSegment(string $segment): string
    {
        return rawurlencode($segment);
    }
}
