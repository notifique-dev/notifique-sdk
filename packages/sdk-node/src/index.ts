import type { NotifiqueConfig } from '@notifique/core';
import { createGeneratedApi, type GeneratedApi } from './generated/api';
import { createHttpTransport } from './http';
import { Notifique as LegacyNotifique } from './legacy-compat';

export { NotifiqueApiError } from '@notifique/core';
export * from '@notifique/core';
export type { GeneratedApi } from './generated/api';
export { createHttpTransport, toCamelCase } from './http';

const LEGACY_NAMESPACES = new Set(['whatsapp', 'sms', 'email', 'messages', 'push']);

/**
 * Official Notifique API v1 client — full OpenAPI coverage via `api` + legacy namespaces
 * for WhatsApp, SMS, Email, Push and template send.
 */
export class Notifique extends LegacyNotifique {
  /** Full generated API (353 operations). */
  public readonly api: GeneratedApi;

  constructor(config: NotifiqueConfig) {
    super(config);
    const http = createHttpTransport({
      apiKey: config.apiKey,
      baseUrl: config.baseUrl?.replace(/\/v1\/?$/, '') ?? 'https://api.notifique.dev',
    });
    this.api = createGeneratedApi(http);

    for (const [key, value] of Object.entries(this.api)) {
      if (key === 'http' || LEGACY_NAMESPACES.has(key)) continue;
      Object.defineProperty(this, key, { value, enumerable: true, configurable: true });
    }
  }
}

/**
 * Public / unauthenticated endpoints (widget público, report, OAuth metadata).
 * Industry pattern: separate lightweight client without API key (Stripe-style split).
 */
export function createPublicClient(options?: { baseUrl?: string }): GeneratedApi {
  const http = createHttpTransport({
    allowAnonymous: true,
    baseUrl: options?.baseUrl?.replace(/\/v1\/?$/, '') ?? 'https://api.notifique.dev',
  });
  return createGeneratedApi(http);
}
