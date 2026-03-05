"""
Tipos da API Notifique — alinhados aos endpoints e ao SDK Node.
Uso: type hints e validação; todos o request/response estão tipados.
"""

from typing import Any, Dict, List, Literal, Optional, TypedDict, Union

# ---------------------------------------------------------------------------
# WhatsApp
# ---------------------------------------------------------------------------

WhatsAppMessageType = Literal[
    "text", "image", "video", "audio", "document", "location", "contact"
]

# Payloads por tipo (API usa message para text, mediaUrl para mídia)
class TextPayload(TypedDict):
    message: str


class MediaPayload(TypedDict):
    mediaUrl: str
    fileName: str
    mimetype: str


class LocationPayload(TypedDict):
    latitude: float
    longitude: float
    name: str
    address: str


class ContactPayload(TypedDict, total=False):
    """Objeto de contato: fullName obrigatório; wuid ou phoneNumber obrigatório."""
    fullName: str
    wuid: str  # Número só dígitos com DDI
    phoneNumber: str
    organization: str
    email: str
    url: str


# Payload para type=contact: payload.contact (objeto) ou payload.contactId (ID do workspace)
class ContactMessagePayload(TypedDict, total=False):
    contact: ContactPayload
    contactId: str


class WhatsAppSchedule(TypedDict, total=False):
    sendAt: str  # ISO 8601


class WhatsAppOptions(TypedDict, total=False):
    priority: Literal["high", "normal", "low"]
    maxRetries: int  # 0-5


# Params para POST /v1/whatsapp/messages (instanceId no body)
class WhatsAppSendParams(TypedDict, total=False):
    instanceId: str
    to: List[str]
    type: WhatsAppMessageType
    payload: Union[TextPayload, MediaPayload, LocationPayload, ContactMessagePayload]
    schedule: WhatsAppSchedule
    options: WhatsAppOptions


class WhatsAppSendResponse(TypedDict, total=False):
    """Resposta de envio; API retorna status em MAIÚSCULO (QUEUED, SCHEDULED)."""
    messageIds: List[str]
    status: Literal["QUEUED", "SCHEDULED"]
    scheduledAt: Optional[str]


class WhatsAppMessageStatus(TypedDict, total=False):
    messageId: str
    to: str
    type: str
    status: str
    scheduledAt: Optional[str]
    sentAt: Optional[str]
    deliveredAt: Optional[str]
    readAt: Optional[str]
    failedAt: Optional[str]
    errorMessage: Optional[str]
    createdAt: str


class WhatsAppMessageActionResponse(TypedDict, total=False):
    """Resposta de cancel/delete/edit; API retorna data.messageId e data.status em MAIÚSCULO."""
    success: bool
    data: Dict[str, Any]  # messageId, status: CANCELLED | DELETED | EDITED


class WhatsAppInstance(TypedDict, total=False):
    id: str
    name: str
    phoneNumber: Optional[str]
    status: str
    createdAt: str
    updatedAt: str


class WhatsAppInstanceListParams(TypedDict, total=False):
    page: str
    limit: str
    status: str
    search: str


class WhatsAppInstanceListResponse(TypedDict, total=False):
    success: bool
    data: List[WhatsAppInstance]
    pagination: Dict[str, int]


class WhatsAppCreateInstanceParams(TypedDict):
    name: str


class WhatsAppCreateInstanceResponse(TypedDict, total=False):
    success: bool
    data: Dict[str, Any]  # instance + connection


class WhatsAppInstanceActionResponse(TypedDict, total=False):
    success: bool
    data: Dict[str, str]
    message: str


class WhatsAppListMessagesParams(TypedDict, total=False):
    page: str
    limit: str
    fromDate: str
    toDate: str
    instanceIds: str
    status: str
    type: str
    includeEvents: str


class WhatsAppListMessagesResponse(TypedDict, total=False):
    success: bool
    data: List[Dict[str, Any]]
    pagination: Dict[str, int]


class WhatsAppInstanceQrResponse(TypedDict, total=False):
    success: bool
    data: Dict[str, Any]  # status, base64


# ---------------------------------------------------------------------------
# SMS
# ---------------------------------------------------------------------------

class SmsSchedule(TypedDict, total=False):
    sendAt: str


class SmsOptions(TypedDict, total=False):
    priority: Literal["high", "normal", "low"]


class SmsSendParams(TypedDict, total=False):
    to: List[str]
    message: str
    schedule: SmsSchedule
    options: SmsOptions


class SmsSendResponse(TypedDict, total=False):
    success: bool
    data: Dict[str, Any]  # status, count, smsIds, scheduledAt?


class SmsStatus(TypedDict, total=False):
    smsId: str
    to: str
    message: str
    status: str
    sentAt: Optional[str]
    deliveredAt: Optional[str]
    failedAt: Optional[str]
    scheduledFor: Optional[str]
    errorMessage: Optional[str]
    createdAt: str


class SmsStatusResponse(TypedDict, total=False):
    success: bool
    data: SmsStatus


class SmsCancelResponse(TypedDict, total=False):
    success: bool
    data: Dict[str, str]  # smsId, status: "CANCELLED"


# ---------------------------------------------------------------------------
# Email
# ---------------------------------------------------------------------------

class EmailSchedule(TypedDict, total=False):
    sendAt: str


class EmailOptions(TypedDict, total=False):
    priority: Literal["high", "normal", "low"]


class EmailSendParams(TypedDict, total=False):
    """Use 'from_address' para o remetente (enviado como 'from' na API)."""
    from_address: str
    fromName: str
    to: List[str]
    subject: str
    text: str
    html: str
    schedule: EmailSchedule
    options: EmailOptions


class EmailSendResponse(TypedDict, total=False):
    success: bool
    data: Dict[str, Any]  # emailIds, status, count, scheduledAt?


class EmailStatus(TypedDict, total=False):
    id: str
    to: str
    from_: str
    fromName: Optional[str]
    subject: str
    status: str
    scheduledFor: Optional[str]
    sentAt: Optional[str]
    deliveredAt: Optional[str]
    failedAt: Optional[str]
    errorMessage: Optional[str]
    createdAt: str


class EmailStatusResponse(TypedDict, total=False):
    success: bool
    data: EmailStatus


class EmailCancelResponse(TypedDict, total=False):
    success: bool
    data: Dict[str, str]  # emailId, status


# ---------------------------------------------------------------------------
# Messages (template) — envio genérico multi-canal
# ---------------------------------------------------------------------------

TemplateChannel = Literal["whatsapp", "sms", "email"]


class MessagesSendParams(TypedDict, total=False):
    """Mesmos parâmetros da API e dos outros SDKs: to, template, variables, channels, instanceId, from_address (→ from), fromName."""
    to: List[str]
    template: str
    variables: Dict[str, Union[str, int]]
    channels: List[TemplateChannel]
    instanceId: str
    from_address: str  # enviado como 'from' na API
    fromName: str


class MessagesSendResponse(TypedDict, total=False):
    success: bool
    data: Dict[str, Any]  # messageIds?, smsIds?, emailIds?, status, count


# ---------------------------------------------------------------------------
# Email Domains
# ---------------------------------------------------------------------------

class EmailDomainItem(TypedDict, total=False):
    id: str
    domain: str
    status: str
    dnsRecords: List[Dict[str, str]]
    verifiedAt: Optional[str]
    createdAt: str
    updatedAt: str


class ListEmailDomainsResponse(TypedDict, total=False):
    success: bool
    data: List[EmailDomainItem]


class CreateEmailDomainRequest(TypedDict):
    domain: str


class CreateEmailDomainResponse(TypedDict, total=False):
    success: bool
    data: EmailDomainItem
    message: str


class GetEmailDomainResponse(TypedDict, total=False):
    success: bool
    data: EmailDomainItem


class VerifyEmailDomainResponse(TypedDict, total=False):
    success: bool
    data: EmailDomainItem
    verified: bool


# ---------------------------------------------------------------------------
# Push
# ---------------------------------------------------------------------------

class PushAppCreateRequest(TypedDict):
    name: str


class PushAppUpdateRequest(TypedDict, total=False):
    name: str
    vapidPublicKey: str
    vapidPrivateKey: str
    allowedOrigins: List[str]
    promptConfig: Dict[str, Any]
    fcmProjectId: str
    fcmServiceAccountJson: str
    apnsKeyId: str
    apnsTeamId: str
    apnsBundleId: str
    apnsKeyP8: str


class PushAppItem(TypedDict, total=False):
    id: str
    name: str
    workspaceId: str
    vapidPublicKey: Optional[str]
    hasVapidPrivate: bool
    hasFcm: bool
    hasApns: bool
    allowedOrigins: List[str]
    promptConfig: Optional[Dict[str, Any]]
    createdAt: str
    updatedAt: str


class PushAppListResponse(TypedDict, total=False):
    success: bool
    data: List[PushAppItem]
    pagination: Dict[str, int]


class PushAppSingleResponse(TypedDict, total=False):
    success: bool
    data: PushAppItem


class PushDeviceRegisterRequest(TypedDict, total=False):
    appId: str
    platform: Literal["web", "android", "ios"]
    subscription: Dict[str, Any]
    token: str
    externalUserId: str


class PushDeviceItem(TypedDict, total=False):
    id: str
    appId: str
    platform: str
    externalUserId: Optional[str]
    createdAt: str


class PushDeviceListResponse(TypedDict, total=False):
    success: bool
    data: List[PushDeviceItem]
    pagination: Dict[str, int]


class PushDeviceSingleResponse(TypedDict, total=False):
    success: bool
    data: PushDeviceItem


class PushSchedule(TypedDict, total=False):
    """OpenAPI: schedule.sendAt (ISO 8601)."""
    sendAt: str


class PushOptions(TypedDict, total=False):
    priority: Literal["high", "normal", "low"]


class SendPushParams(TypedDict, total=False):
    """Alinhado a SendPushRequest do OpenAPI push-api."""
    to: List[str]
    title: str
    body: str
    url: str
    icon: str
    image: str
    data: Dict[str, Any]
    schedule: PushSchedule
    options: PushOptions


class SendPushResponse(TypedDict, total=False):
    success: bool
    data: Dict[str, Any]


class PushMessageItem(TypedDict, total=False):
    id: str
    deviceId: str
    appId: str
    title: str
    body: str
    status: str
    scheduledFor: Optional[str]
    sentAt: Optional[str]
    deliveredAt: Optional[str]
    failedAt: Optional[str]
    errorMessage: Optional[str]
    clickedAt: Optional[str]
    createdAt: str


class PushMessageListResponse(TypedDict, total=False):
    success: bool
    data: List[PushMessageItem]
    pagination: Dict[str, int]


class PushMessageSingleResponse(TypedDict, total=False):
    success: bool
    data: PushMessageItem


class CancelPushResponse(TypedDict, total=False):
    success: bool
    data: Dict[str, str]
