<?php

namespace Notifique\Generated;

use Notifique\Notifique;

/**
 * Nested namespace proxy for dynamic OpenAPI operations.
 */
class ApiNamespace
{
    /** @var array<string, self> */
    private array $children = [];

    /**
     * @param list<string> $segments
     */
    public function __construct(
        private readonly Notifique $client,
        private readonly array $segments = []
    ) {
    }

    public function __get(string $name): self
    {
        if (!isset($this->children[$name])) {
            $this->children[$name] = new self($this->client, [...$this->segments, $name]);
        }

        return $this->children[$name];
    }

    /**
     * @param array<int, mixed> $arguments
     * @return array<string, mixed>
     */
    public function __call(string $methodName, array $arguments): array
    {
        $operation = OperationRegistry::find($this->segments, $methodName);
        if ($operation === null) {
            $path = $this->segments === [] ? $methodName : implode('.', $this->segments) . '.' . $methodName;
            throw new \BadMethodCallException('Unknown operation: ' . $path);
        }

        $pathParams = [];
        $options = [];

        if (!empty($operation['pathParams'])) {
            $pathParams = is_array($arguments[0] ?? null) ? $arguments[0] : [];
            $options = is_array($arguments[1] ?? null) ? $arguments[1] : [];
        } elseif (isset($arguments[0]) && is_array($arguments[0])) {
            $options = $arguments[0];
        }

        $url = self::buildUrl((string) $operation['urlTemplate'], $pathParams);
        if (!empty($options['query']) && is_array($options['query'])) {
            $url .= '?' . http_build_query($options['query']);
        }

        $body = $options['body'] ?? null;
        $requestOptions = [];
        if (!empty($options['idempotencyKey']) && is_string($options['idempotencyKey'])) {
            $requestOptions['headers'] = ['Idempotency-Key' => $options['idempotencyKey']];
        }

        $method = (string) $operation['httpMethod'];
        if (in_array($method, ['GET', 'DELETE'], true)) {
            $body = null;
        }

        return $this->client->apiRequest($method, $url, is_array($body) ? $body : null, $requestOptions);
    }

    /**
     * @param array<string, scalar|null> $pathParams
     */
    private static function buildUrl(string $template, array $pathParams): string
    {
        $url = $template;
        foreach ($pathParams as $key => $value) {
            $url = str_replace(
                '{' . $key . '}',
                rawurlencode((string) $value),
                $url
            );
        }

        return $url;
    }

    /**
     * @return list<string>
     */
    public function segments(): array
    {
        return $this->segments;
    }

    public function hasOperation(string $methodName): bool
    {
        return OperationRegistry::find($this->segments, $methodName) !== null;
    }
}
