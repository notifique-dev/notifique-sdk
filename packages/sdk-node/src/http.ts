import axios, { AxiosInstance, AxiosError } from 'axios';
import { NotifiqueApiError } from '@notifique/core';

export interface HttpRequestOptions {
  query?: Record<string, unknown>;
  body?: unknown;
  idempotencyKey?: string;
  headers?: Record<string, string>;
}

export interface HttpTransport {
  request<T = unknown>(method: string, url: string, options?: HttpRequestOptions): Promise<T>;
  getAxios(): AxiosInstance;
}

export interface HttpConfig {
  apiKey?: string;
  baseUrl?: string;
  timeoutMs?: number;
  /** Allow calls without Bearer token (public endpoints). */
  allowAnonymous?: boolean;
}

function assertSecureBaseUrl(baseUrl: string): void {
  let parsed: URL;
  try {
    parsed = new URL(baseUrl);
  } catch {
    throw new Error('Notifique: baseUrl must be a valid absolute URL');
  }
  if (parsed.protocol !== 'https:') {
    throw new Error('Notifique: baseUrl must use HTTPS');
  }
}

/** Converts API snake_case JSON to camelCase for SDK consumers. */
export function toCamelCase<T>(value: unknown): T {
  if (value === null || value === undefined) return value as T;
  if (Array.isArray(value)) return value.map((item) => toCamelCase(item)) as T;
  if (typeof value === 'object') {
    const out: Record<string, unknown> = {};
    for (const [k, v] of Object.entries(value)) {
      const camel = k.replace(/_([a-z])/g, (_, c) => c.toUpperCase());
      out[camel] = toCamelCase(v);
    }
    return out as T;
  }
  return value as T;
}

export function createHttpTransport(config: HttpConfig): HttpTransport {
  const apiKey = config.apiKey?.trim();
  if (!config.allowAnonymous && (!apiKey || apiKey === '')) {
    throw new Error('Notifique: apiKey must be a non-empty string');
  }
  const baseUrl = config.baseUrl ?? 'https://api.notifique.dev';
  assertSecureBaseUrl(baseUrl);

  const client = axios.create({
    baseURL: baseUrl,
    timeout: config.timeoutMs ?? 30_000,
    headers: {
      ...(apiKey ? { Authorization: `Bearer ${apiKey}` } : {}),
      'Content-Type': 'application/json',
    },
  });

  client.interceptors.response.use(
    (response) => {
      if (response.data !== undefined) {
        response.data = toCamelCase(response.data);
      }
      return response;
    },
    (error: unknown) => {
      if (axios.isAxiosError(error)) {
        const status = error.response?.status ?? 0;
        const data = error.response?.data as Record<string, unknown> | undefined;
        let message =
          typeof data === 'object' &&
          data !== null &&
          'message' in data &&
          typeof data.message === 'string'
            ? data.message
            : error.message;
        const details =
          typeof data === 'object' && data !== null && Array.isArray(data.details)
            ? data.details
            : undefined;
        if (details && details.length > 0) {
          const parts = (details as Array<{ field?: string; message?: string }>).map((d) =>
            d.field ? `${d.field}: ${d.message ?? ''}` : String(d.message ?? '')
          );
          if (parts.length) message = `${message} (${parts.join('; ')})`;
        }
        throw new NotifiqueApiError(message, status, {
          code: error.code,
          responseData: data,
        });
      }
      throw error;
    }
  );

  return {
    getAxios: () => client,
    async request<T>(method: string, url: string, options?: HttpRequestOptions): Promise<T> {
      const headers: Record<string, string> = { ...(options?.headers ?? {}) };
      if (options?.idempotencyKey) {
        headers['Idempotency-Key'] = options.idempotencyKey;
        headers['x-idempotency-key'] = options.idempotencyKey;
      }
      const m = method.toLowerCase();
      const response = await client.request<T>({
        method: m,
        url,
        params: options?.query,
        data: options?.body,
        headers,
      });
      return response.data as T;
    },
  };
}
