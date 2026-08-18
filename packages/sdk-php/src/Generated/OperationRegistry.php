<?php

namespace Notifique\Generated;

/**
 * Loads and indexes OpenAPI operations from resources/operations.json.
 */
final class OperationRegistry
{
    private static ?array $data = null;

    /** @var array<string, array<string, mixed>>|null */
    private static ?array $index = null;

    public static function load(): array
    {
        if (self::$data === null) {
            $path = dirname(__DIR__, 2) . '/resources/operations.json';
            $json = file_get_contents($path);
            if ($json === false) {
                throw new \RuntimeException('Unable to read operations registry: ' . $path);
            }
            self::$data = json_decode($json, true, 512, JSON_THROW_ON_ERROR);
        }

        return self::$data;
    }

    /**
     * @return list<array<string, mixed>>
     */
    public static function operations(): array
    {
        return self::load()['operations'];
    }

    public static function count(): int
    {
        return (int) self::load()['count'];
    }

    /**
     * @param list<string> $namespaces
     * @return array<string, mixed>|null
     */
    public static function find(array $namespaces, string $methodName): ?array
    {
        if (self::$index === null) {
            self::$index = [];
            foreach (self::operations() as $operation) {
                $key = implode('.', [...$operation['namespaces'], $operation['methodName']]);
                self::$index[$key] = $operation;
            }
        }

        $key = implode('.', [...$namespaces, $methodName]);

        return self::$index[$key] ?? null;
    }

    /**
     * @return list<string>
     */
    public static function operationPaths(): array
    {
        $paths = [];
        foreach (self::operations() as $operation) {
            $paths[] = implode('.', [...$operation['namespaces'], $operation['methodName']]);
        }

        return $paths;
    }

    /**
     * @return list<string>
     */
    public static function topLevelNamespaces(): array
    {
        $namespaces = [];
        foreach (self::operations() as $operation) {
            if (!empty($operation['namespaces'])) {
                $namespaces[$operation['namespaces'][0]] = true;
            }
        }

        return array_keys($namespaces);
    }
}
