/** Merged OpenAPI paths and helpers for typed `client.api` — auto-generated */
import type { paths as paths0 } from './schemas/whatsapp-api_api-reference_openapi-whatsapp';
import type { paths as paths1 } from './schemas/sms-api_api-reference_openapi-sms';
import type { paths as paths2 } from './schemas/telegram-api_api-reference_openapi-telegram';
import type { paths as paths3 } from './schemas/instagram-api_api-reference_openapi-instagram';
import type { paths as paths4 } from './schemas/emails-api_api-reference_openapi-email';
import type { paths as paths5 } from './schemas/push-api_api-reference_openapi-push';
import type { paths as paths6 } from './schemas/rcs-api_api-reference_openapi-rcs';
import type { paths as paths7 } from './schemas/voice-api_api-reference_openapi-voice';
import type { paths as paths8 } from './schemas/platform-api_api-reference_openapi-platform';
import type { paths as paths9 } from './schemas/oauth-api_api-reference_openapi-oauth';
import type { paths as paths10 } from './schemas/guides_webhooks_api-reference_openapi-webhooks';
import type { paths as paths11 } from './schemas/guides_logs_api-reference_openapi-logs';
import type { paths as paths12 } from './schemas/guides_workspaces_api-reference_openapi-workspaces';
import type { paths as paths13 } from './schemas/phone-numbers-api_api-reference_openapi-phone-numbers';
import type { paths as paths14 } from './schemas/contacts-api_api-reference_openapi-contacts';
import type { paths as paths15 } from './schemas/template-api_api-reference_openapi-templates';
import type { paths as paths16 } from './schemas/automations-api_api-reference_openapi-automations';
import type { paths as paths17 } from './schemas/marketing-addons-api_api-reference_openapi-marketing-addons';
import type { paths as paths18 } from './schemas/short-links-api_api-reference_openapi-short-links';
import type { paths as paths19 } from './schemas/short-links-api_api-reference_openapi-conversions';
import type { paths as paths20 } from './schemas/ai-web-widget_api-reference_openapi-ai-web-widget';
import type { paths as paths21 } from './schemas/suppressions-api_api-reference_openapi-suppressions';
import type { paths as paths22 } from './schemas/guides_compliance_openapi-report';

export type ApiPaths =
  & paths0
  & paths1
  & paths2
  & paths3
  & paths4
  & paths5
  & paths6
  & paths7
  & paths8
  & paths9
  & paths10
  & paths11
  & paths12
  & paths13
  & paths14
  & paths15
  & paths16
  & paths17
  & paths18
  & paths19
  & paths20
  & paths21
  & paths22

export type HttpMethodLower = 'get' | 'post' | 'put' | 'patch' | 'delete';

export type OpFor<P extends keyof ApiPaths, M extends HttpMethodLower> =
  ApiPaths[P] extends Record<M, infer Op> ? Op : never;

type JsonMedia<C> = C extends { 'application/json': infer T } ? T : never;
type ResponseBody<R> = R extends { content: infer C } ? JsonMedia<C> : never;

type SuccessResponse<Res> =
  ResponseBody<Res extends { 200: infer R0 } ? R0 : never> |
  ResponseBody<Res extends { 201: infer R1 } ? R1 : never> |
  ResponseBody<Res extends { 202: infer R2 } ? R2 : never> |
  ResponseBody<Res extends { 204: infer R3 } ? R3 : never>;

export type OpResponse<P extends keyof ApiPaths, M extends HttpMethodLower> =
  OpFor<P, M> extends { responses: infer Res } ? SuccessResponse<Res> : unknown;

export type OpRequestBody<P extends keyof ApiPaths, M extends HttpMethodLower> =
  OpFor<P, M> extends { requestBody?: infer RB }
    ? RB extends { content: infer C } ? JsonMedia<C> : never
    : never;

export type OpQuery<P extends keyof ApiPaths, M extends HttpMethodLower> =
  OpFor<P, M> extends { parameters: { query?: infer Q } } ? Q : never;

export type OpPathParams<P extends keyof ApiPaths, M extends HttpMethodLower> =
  OpFor<P, M> extends { parameters: { path: infer Path } } ? Path : never;
