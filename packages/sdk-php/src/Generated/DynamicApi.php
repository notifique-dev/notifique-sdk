<?php

namespace Notifique\Generated;

use Notifique\Notifique;

/**
 * Builds the dynamic OpenAPI client tree from operations.json.
 */
final class DynamicApi
{
    /** @var list<string> */
    public const LEGACY_NAMESPACES = ['whatsapp', 'sms', 'email', 'messages', 'push'];

    public static function create(Notifique $client): ApiNamespace
    {
        return new ApiNamespace($client);
    }

    public static function attachNamespaces(Notifique $client): void
    {
        foreach (OperationRegistry::topLevelNamespaces() as $namespace) {
            if (in_array($namespace, self::LEGACY_NAMESPACES, true)) {
                continue;
            }
            $client->attachDynamicNamespace($namespace);
        }
    }
}
