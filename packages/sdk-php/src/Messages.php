<?php

namespace Notifique;

/**
 * Messages (templates) — POST /v1/templates/send
 */
class Messages
{
    private Notifique $client;

    public function __construct(Notifique $client)
    {
        $this->client = $client;
    }

    /**
     * POST /v1/templates/send — envio por template (whatsapp, sms, email).
     * Parâmetros (mesmos da API): to, template, variables?, channels, instanceId?, from?, fromName?
     *
     * @param array{to: list<string>, template: string, variables?: array<string, string|int>, channels: list<string>, instanceId?: string, from?: string, fromName?: string} $params
     */
    public function send(array $params): array
    {
        if (isset($params['from_name']) && !\array_key_exists('fromName', $params)) {
            $params['fromName'] = $params['from_name'];
            unset($params['from_name']);
        }
        if (isset($params['instance_id']) && !\array_key_exists('instanceId', $params)) {
            $params['instanceId'] = $params['instance_id'];
            unset($params['instance_id']);
        }
        return $this->client->request('POST', '/templates/send', $params);
    }
}
