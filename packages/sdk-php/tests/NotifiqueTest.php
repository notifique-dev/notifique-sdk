<?php

namespace Notifique\Tests;

use PHPUnit\Framework\TestCase;
use GuzzleHttp\Handler\MockHandler;
use GuzzleHttp\HandlerStack;
use GuzzleHttp\Psr7\Response;
use GuzzleHttp\Middleware;
use Notifique\Notifique;
use Notifique\Exception\NotifiqueApiException;

class NotifiqueTest extends TestCase
{
    private array $container = [];

    private function getMockClient(array $responses): Notifique
    {
        $mock = new MockHandler($responses);
        $history = Middleware::history($this->container);
        $handlerStack = HandlerStack::create($mock);
        $handlerStack->push($history);
        return new Notifique('test-key', 'https://api.notifique.dev/v1', ['handler' => $handlerStack]);
    }

    public function testWhatsAppSendText(): void
    {
        $client = $this->getMockClient([
            new Response(202, [], json_encode(['success' => true, 'data' => ['messageIds' => ['msg-123'], 'status' => 'QUEUED']])),
        ]);
        $resp = $client->whatsapp->sendText('instance-1', ['5511999999999'], 'Hello');
        $this->assertIsArray($resp);
        $this->assertSame(['msg-123'], $resp['data']['messageIds']);
        $this->assertSame('QUEUED', $resp['data']['status']);
    }

    public function testWhatsAppSendErrorThrows(): void
    {
        $client = $this->getMockClient([
            new Response(400, [], json_encode(['error' => 'Invalid instance'])),
        ]);
        $this->expectException(NotifiqueApiException::class);
        $client->whatsapp->sendText('x', ['123'], 'hi');
    }

    public function testWhatsAppSendWithParams(): void
    {
        $client = $this->getMockClient([
            new Response(202, [], json_encode(['success' => true, 'data' => ['messageIds' => ['m1'], 'status' => 'QUEUED']])),
        ]);
        $resp = $client->whatsapp->send('instance-1', [
            'to' => ['5511888888888'],
            'type' => 'text',
            'payload' => ['message' => 'Hi'],
        ]);
        $this->assertSame(['m1'], $resp['data']['messageIds']);
    }

    public function testWhatsAppSendWithIdempotencyKey(): void
    {
        $client = $this->getMockClient([
            new Response(202, [], json_encode(['success' => true, 'data' => ['messageIds' => ['m1'], 'status' => 'QUEUED']])),
        ]);
        $client->whatsapp->send('instance-1', [
            'to' => ['5511888888888'],
            'type' => 'text',
            'payload' => ['message' => 'Hi'],
        ], 'wa-idem-456');
        $this->assertCount(1, $this->container);
        $this->assertSame('wa-idem-456', $this->container[0]['request']->getHeaderLine('Idempotency-Key'));
    }

    public function testWhatsAppGetMessage(): void
    {
        $client = $this->getMockClient([
            new Response(200, [], json_encode(['success' => true, 'data' => ['messageId' => 'msg-1', 'status' => 'DELIVERED']])),
        ]);
        $resp = $client->whatsapp->getMessage('msg-1');
        $this->assertSame('msg-1', $resp['data']['messageId']);
        $this->assertSame('DELIVERED', $resp['data']['status']);
    }

    public function testWhatsAppListInstances(): void
    {
        $client = $this->getMockClient([
            new Response(200, [], json_encode(['success' => true, 'data' => [], 'pagination' => ['total' => 0]])),
        ]);
        $resp = $client->whatsapp->listInstances();
        $this->assertTrue($resp['success']);
    }

    public function testSmsSend(): void
    {
        $client = $this->getMockClient([
            new Response(202, [], json_encode([
                'success' => true,
                'data' => ['status' => 'QUEUED', 'count' => 1, 'smsIds' => ['sms-1']],
            ])),
        ]);
        $resp = $client->sms->send(['to' => ['5511999999999'], 'message' => 'Test']);
        $this->assertTrue($resp['success']);
        $this->assertSame(['sms-1'], $resp['data']['smsIds']);
        $this->assertSame('QUEUED', $resp['data']['status']);
    }

    public function testSmsSendWithIdempotencyKey(): void
    {
        $client = $this->getMockClient([
            new Response(202, [], json_encode([
                'success' => true,
                'data' => ['status' => 'QUEUED', 'count' => 1, 'smsIds' => ['sms-1']],
            ])),
        ]);
        $client->sms->send(['to' => ['5511999999999'], 'message' => 'Test'], 'my-idempotency-key');
        $this->assertCount(1, $this->container);
        $req = $this->container[0]['request'];
        $this->assertSame('my-idempotency-key', $req->getHeaderLine('Idempotency-Key'));
    }

    public function testSmsGet(): void
    {
        $client = $this->getMockClient([
            new Response(200, [], json_encode([
                'success' => true,
                'data' => ['smsId' => 'sms-1', 'status' => 'delivered'],
            ])),
        ]);
        $resp = $client->sms->get('sms-1');
        $this->assertSame('sms-1', $resp['data']['smsId']);
    }

    public function testSmsCancel(): void
    {
        $client = $this->getMockClient([
            new Response(200, [], json_encode([
                'success' => true,
                'data' => ['smsId' => 'sms-1', 'status' => 'cancelled'],
            ])),
        ]);
        $resp = $client->sms->cancel('sms-1');
        $this->assertTrue($resp['success']);
        $this->assertSame('cancelled', $resp['data']['status']);
    }

    public function testEmailSend(): void
    {
        $client = $this->getMockClient([
            new Response(202, [], json_encode([
                'success' => true,
                'data' => ['emailIds' => ['email-1'], 'status' => 'QUEUED', 'count' => 1],
            ])),
        ]);
        $resp = $client->email->send([
            'from' => 'noreply@example.com',
            'to' => ['u@example.com'],
            'subject' => 'Test',
            'text' => 'Body',
        ]);
        $this->assertSame(['email-1'], $resp['data']['emailIds']);
        $this->assertSame('QUEUED', $resp['data']['status']);
    }

    public function testEmailSendConvertsFromNameToCamelCase(): void
    {
        $client = $this->getMockClient([
            new Response(202, [], json_encode([
                'success' => true,
                'data' => ['emailIds' => ['e1'], 'status' => 'QUEUED', 'count' => 1],
            ])),
        ]);
        $client->email->send([
            'from' => 'noreply@example.com',
            'from_name' => 'Suporte',
            'to' => ['u@example.com'],
            'subject' => 'Test',
            'html' => '<p>Hi</p>',
        ]);
        $this->assertCount(1, $this->container);
        $body = json_decode($this->container[0]['request']->getBody()->getContents(), true);
        $this->assertArrayHasKey('fromName', $body);
        $this->assertSame('Suporte', $body['fromName']);
        $this->assertArrayNotHasKey('from_name', $body);
    }

    public function testEmailSendWithIdempotencyKey(): void
    {
        $client = $this->getMockClient([
            new Response(202, [], json_encode([
                'success' => true,
                'data' => ['emailIds' => ['email-1'], 'status' => 'QUEUED', 'count' => 1],
            ])),
        ]);
        $client->email->send([
            'from' => 'noreply@example.com',
            'to' => ['u@example.com'],
            'subject' => 'Test',
            'text' => 'Body',
        ], 'email-idem-123');
        $this->assertCount(1, $this->container);
        $this->assertSame('email-idem-123', $this->container[0]['request']->getHeaderLine('Idempotency-Key'));
    }

    public function testEmailCancel(): void
    {
        $client = $this->getMockClient([
            new Response(200, [], json_encode([
                'success' => true,
                'data' => ['emailId' => 'email-1', 'status' => 'cancelled'],
            ])),
        ]);
        $resp = $client->email->cancel('email-1');
        $this->assertTrue($resp['success']);
    }

    public function testMessagesSend(): void
    {
        $client = $this->getMockClient([
            new Response(200, [], json_encode([
                'success' => true,
                'data' => ['messageIds' => ['m1', 'm2'], 'status' => 'queued', 'count' => 2],
            ])),
        ]);
        $resp = $client->messages->send([
            'to' => ['5511999999999'],
            'template' => 'welcome',
            'variables' => ['name' => 'User'],
            'channels' => ['whatsapp', 'sms'],
            'instanceId' => 'inst-1',
        ]);
        $this->assertSame(['m1', 'm2'], $resp['data']['messageIds']);
    }

    public function testPushMessagesSend(): void
    {
        $client = $this->getMockClient([
            new Response(202, [], json_encode([
                'success' => true,
                'data' => ['status' => 'QUEUED', 'count' => 1, 'pushIds' => ['push-1']],
            ])),
        ]);
        $resp = $client->push->messages->send([
            'to' => ['device-1'],
            'title' => 'Hi',
            'body' => 'Test push',
        ]);
        $this->assertTrue($resp['success']);
        $this->assertSame(['push-1'], $resp['data']['pushIds']);
        $this->assertSame('QUEUED', $resp['data']['status']);
    }

    public function testPushMessagesSendWithIdempotencyKey(): void
    {
        $client = $this->getMockClient([
            new Response(202, [], json_encode([
                'success' => true,
                'data' => ['status' => 'QUEUED', 'count' => 1, 'pushIds' => ['push-1']],
            ])),
        ]);
        $client->push->messages->send(
            ['to' => ['device-1'], 'title' => 'Hi', 'body' => 'Body'],
            'push-idem-789'
        );
        $this->assertCount(1, $this->container);
        $this->assertSame('push-idem-789', $this->container[0]['request']->getHeaderLine('Idempotency-Key'));
    }
}
