<?php

namespace Notifique\Tests;

use Notifique\Generated\ApiNamespace;
use Notifique\Generated\OperationRegistry;
use PHPUnit\Framework\TestCase;

class OpenApiCoverageTest extends TestCase
{
    public function testRegistryHas353Operations(): void
    {
        $this->assertSame(353, OperationRegistry::count());
        $this->assertCount(353, OperationRegistry::operations());
    }

    public function testDynamicApiExposesEveryRegistryOperation(): void
    {
        $client = $this->createMock(\Notifique\Notifique::class);
        $api = new ApiNamespace($client);

        $missing = [];
        foreach (OperationRegistry::operations() as $operation) {
            $namespace = $api;
            foreach ($operation['namespaces'] as $segment) {
                $namespace = $namespace->{$segment};
            }
            if (!$namespace->hasOperation($operation['methodName'])) {
                $missing[] = implode('.', [...$operation['namespaces'], $operation['methodName']]);
            }
        }

        $this->assertSame([], $missing);
    }

    public function testTopLevelNamespacesIncludeOpenApiRoots(): void
    {
        $topLevel = OperationRegistry::topLevelNamespaces();
        $this->assertContains('wellKnown', $topLevel);
        $this->assertContains('oauth', $topLevel);
        $this->assertContains('whatsapp', $topLevel);
        $this->assertContains('templates', $topLevel);
    }
}
