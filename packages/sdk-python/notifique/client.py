"""
Cliente Notifique — WhatsApp, SMS, Email, Push e envio por template (messages).
Alinhado à API v1 (api.notifique.dev).
"""

from typing import Any, Dict, List, Optional, Union

import requests


class NotifiqueApiError(Exception):
    """Erro retornado pela API Notifique (4xx/5xx)."""

    def __init__(
        self,
        message: str,
        status_code: int,
        *,
        response_data: Optional[Dict[str, Any]] = None,
    ) -> None:
        super().__init__(message)
        self.message = message
        self.status_code = status_code
        self.response_data = response_data or {}

from .types import (
    WhatsAppCreateInstanceParams,
    WhatsAppCreateInstanceResponse,
    WhatsAppInstanceActionResponse,
    WhatsAppInstanceListParams,
    WhatsAppInstanceListResponse,
    WhatsAppInstanceQrResponse,
    WhatsAppListMessagesParams,
    WhatsAppListMessagesResponse,
    WhatsAppMessageActionResponse,
    WhatsAppMessageStatus,
    WhatsAppSendParams,
    WhatsAppSendResponse,
    CreateEmailDomainRequest,
    CreateEmailDomainResponse,
    EmailCancelResponse,
    EmailSendParams,
    EmailSendResponse,
    EmailStatusResponse,
    GetEmailDomainResponse,
    ListEmailDomainsResponse,
    MessagesSendParams,
    MessagesSendResponse,
    PushAppCreateRequest,
    PushAppUpdateRequest,
    PushAppListResponse,
    PushAppSingleResponse,
    PushDeviceRegisterRequest,
    PushDeviceListResponse,
    PushDeviceSingleResponse,
    SendPushParams,
    SendPushResponse,
    PushMessageListResponse,
    PushMessageSingleResponse,
    CancelPushResponse,
    SmsCancelResponse,
    SmsSendParams,
    SmsSendResponse,
    SmsStatusResponse,
    VerifyEmailDomainResponse,
)


def _prepare_email_params(params: Dict[str, Any]) -> Dict[str, Any]:
    """Converte from_address -> from para a API."""
    out = dict(params)
    if "from_address" in out:
        out["from"] = out.pop("from_address")
    return out


def _prepare_messages_params(params: Dict[str, Any]) -> Dict[str, Any]:
    """Converte from_address -> from e instance_id -> instanceId para a API."""
    out = dict(params)
    if "from_address" in out:
        out["from"] = out.pop("from_address")
    if "instance_id" in out:
        out["instanceId"] = out.pop("instance_id")
    return out


class WhatsAppNamespace:
    """POST/GET/DELETE/PATCH /v1/whatsapp/... e /v1/whatsapp/instances/..."""

    def __init__(self, client: "Notifique") -> None:
        self._client = client

    def send(
        self,
        instance_id: str,
        params: Union[WhatsAppSendParams, Dict[str, Any]],
    ) -> Any:
        """POST /v1/whatsapp/messages — Envia uma ou mais mensagens (1–100 destinatários)."""
        body = dict(params) if isinstance(params, dict) else dict(params)
        body["instanceId"] = instance_id
        return self._client._request("POST", "/whatsapp/messages", json=body)

    def send_text(
        self,
        instance_id: str,
        to: Union[str, List[str]],
        text: str,
    ) -> Any:
        """Atalho: envia mensagem de texto (payload.message)."""
        destinations = [to] if isinstance(to, str) else list(to)
        return self.send(
            instance_id,
            {
                "to": destinations,
                "type": "text",
                "payload": {"message": text},
            },
        )

    def list_messages(
        self,
        params: Optional[Union[WhatsAppListMessagesParams, Dict[str, str]]] = None,
    ) -> WhatsAppListMessagesResponse:
        """GET /v1/whatsapp/messages — Lista mensagens com paginação."""
        return self._client._request(
            "GET", "/whatsapp/messages", params=params or {}
        )

    def get_message(self, message_id: str) -> Any:
        """GET /v1/whatsapp/messages/:messageId — Status da mensagem (retorna envelope success/data)."""
        return self._client._request("GET", f"/whatsapp/messages/{message_id}")

    def delete_message(self, message_id: str) -> WhatsAppMessageActionResponse:
        """DELETE /v1/whatsapp/messages/:messageId — Apagar para todos."""
        return self._client._request("DELETE", f"/whatsapp/messages/{message_id}")

    def edit_message(self, message_id: str, text: str) -> WhatsAppMessageActionResponse:
        """PATCH /v1/whatsapp/messages/:messageId/edit — Editar texto."""
        return self._client._request(
            "PATCH", f"/whatsapp/messages/{message_id}/edit", json={"text": text}
        )

    def cancel_message(self, message_id: str) -> WhatsAppMessageActionResponse:
        """POST /v1/whatsapp/messages/:messageId/cancel — Cancelar agendada."""
        return self._client._request("POST", f"/whatsapp/messages/{message_id}/cancel")

    def list_instances(
        self,
        params: Optional[Union[WhatsAppInstanceListParams, Dict[str, str]]] = None,
    ) -> WhatsAppInstanceListResponse:
        """GET /v1/whatsapp/instances — Lista instâncias."""
        return self._client._request(
            "GET", "/whatsapp/instances", params=params or {}
        )

    def get_instance(self, instance_id: str) -> Dict[str, Any]:
        """GET /v1/whatsapp/instances/:id."""
        return self._client._request("GET", f"/whatsapp/instances/{instance_id}")

    def get_instance_qr(self, instance_id: str) -> WhatsAppInstanceQrResponse:
        """GET /v1/whatsapp/instances/:id/qr — QR code atual da instância."""
        return self._client._request("GET", f"/whatsapp/instances/{instance_id}/qr")

    def create_instance(
        self,
        params: Union[WhatsAppCreateInstanceParams, Dict[str, str]],
    ) -> WhatsAppCreateInstanceResponse:
        """POST /v1/whatsapp/instances — Cria instância (QR/status)."""
        return self._client._request("POST", "/whatsapp/instances", json=params)

    def disconnect_instance(self, instance_id: str) -> WhatsAppInstanceActionResponse:
        """POST /v1/whatsapp/instances/:id/disconnect."""
        return self._client._request(
            "POST", f"/whatsapp/instances/{instance_id}/disconnect"
        )

    def delete_instance(self, instance_id: str) -> WhatsAppInstanceActionResponse:
        """DELETE /v1/whatsapp/instances/:id (instância não pode estar ACTIVE)."""
        return self._client._request("DELETE", f"/whatsapp/instances/{instance_id}")


class SmsNamespace:
    """POST /v1/sms/messages, GET /v1/sms/messages/:id, POST /v1/sms/messages/:id/cancel."""

    def __init__(self, client: "Notifique") -> None:
        self._client = client

    def send(self, params: Union[SmsSendParams, Dict[str, Any]]) -> SmsSendResponse:
        """POST /v1/sms/messages — Envia um ou mais SMS (1–100 números)."""
        return self._client._request("POST", "/sms/messages", json=params)

    def get(self, sms_id: str) -> SmsStatusResponse:
        """GET /v1/sms/messages/:id — Status do SMS."""
        return self._client._request("GET", f"/sms/messages/{sms_id}")

    def cancel(self, sms_id: str) -> SmsCancelResponse:
        """POST /v1/sms/messages/:id/cancel — Cancela SMS agendado (status SCHEDULED). Escopo: sms:cancel."""
        return self._client._request("POST", f"/sms/messages/{sms_id}/cancel")


class EmailNamespace:
    """POST /v1/email/messages, GET /v1/email/messages/:id, POST /v1/email/messages/:id/cancel e domínios."""

    def __init__(self, client: "Notifique") -> None:
        self._client = client

    def send(
        self,
        params: Union[EmailSendParams, Dict[str, Any]],
    ) -> EmailSendResponse:
        """POST /v1/email/messages — Envia e-mail(s). Use from_address no dict."""
        return self._client._request(
            "POST", "/email/messages", json=_prepare_email_params(dict(params))
        )

    def get(self, email_id: str) -> EmailStatusResponse:
        """GET /v1/email/messages/:id — Status do e-mail."""
        return self._client._request("GET", f"/email/messages/{email_id}")

    def cancel(self, email_id: str) -> EmailCancelResponse:
        """POST /v1/email/messages/:id/cancel — Cancela e-mail agendado."""
        return self._client._request("POST", f"/email/messages/{email_id}/cancel")


class EmailDomainsNamespace:
    """GET/POST /v1/email/domains, GET /v1/email/domains/:id, POST /v1/email/domains/:id/verify."""

    def __init__(self, client: "Notifique") -> None:
        self._client = client

    def list(self) -> ListEmailDomainsResponse:
        """GET /v1/email/domains — Lista domínios."""
        return self._client._request("GET", "/email/domains")

    def create(
        self,
        params: Union[CreateEmailDomainRequest, Dict[str, str]],
    ) -> CreateEmailDomainResponse:
        """POST /v1/email/domains — Registra domínio para verificação."""
        return self._client._request("POST", "/email/domains", json=params)

    def get(self, domain_id: str) -> GetEmailDomainResponse:
        """GET /v1/email/domains/:id."""
        return self._client._request("GET", f"/email/domains/{domain_id}")

    def verify(self, domain_id: str) -> VerifyEmailDomainResponse:
        """POST /v1/email/domains/:id/verify — Verifica domínio (DNS)."""
        return self._client._request("POST", f"/email/domains/{domain_id}/verify")


class MessagesNamespace:
    """POST /v1/templates/send — Envio genérico por template (whatsapp, sms, email)."""

    def __init__(self, client: "Notifique") -> None:
        self._client = client

    def send(
        self,
        params: Union[MessagesSendParams, Dict[str, Any]],
    ) -> MessagesSendResponse:
        """Envia por template para os canais indicados. Use from_address se canal email."""
        return self._client._request(
            "POST", "/templates/send", json=_prepare_messages_params(dict(params))
        )


class PushAppsNamespace:
    """GET/POST /v1/push/apps, GET/PUT/DELETE /v1/push/apps/:id."""

    def __init__(self, client: "Notifique") -> None:
        self._client = client

    def list(
        self,
        params: Optional[Dict[str, int]] = None,
    ) -> PushAppListResponse:
        """GET /v1/push/apps."""
        return self._client._request("GET", "/push/apps", params=params or {})

    def get(self, app_id: str) -> PushAppSingleResponse:
        """GET /v1/push/apps/:id."""
        return self._client._request("GET", f"/push/apps/{app_id}")

    def create(
        self,
        params: Union[PushAppCreateRequest, Dict[str, str]],
    ) -> PushAppSingleResponse:
        """POST /v1/push/apps."""
        return self._client._request("POST", "/push/apps", json=params)

    def update(
        self,
        app_id: str,
        params: Union[PushAppUpdateRequest, Dict[str, Any]],
    ) -> PushAppSingleResponse:
        """PUT /v1/push/apps/:id."""
        return self._client._request("PUT", f"/push/apps/{app_id}", json=params)

    def delete(self, app_id: str) -> Dict[str, Any]:
        """DELETE /v1/push/apps/:id."""
        return self._client._request("DELETE", f"/push/apps/{app_id}")


class PushDevicesNamespace:
    """POST/GET /v1/push/devices, GET/DELETE /v1/push/devices/:id."""

    def __init__(self, client: "Notifique") -> None:
        self._client = client

    def register(
        self,
        params: Union[PushDeviceRegisterRequest, Dict[str, Any]],
    ) -> PushDeviceSingleResponse:
        """POST /v1/push/devices — Registra dispositivo/subscription."""
        return self._client._request("POST", "/push/devices", json=params)

    def list(
        self,
        params: Optional[Dict[str, Any]] = None,
    ) -> PushDeviceListResponse:
        """GET /v1/push/devices."""
        return self._client._request("GET", "/push/devices", params=params or {})

    def get(self, device_id: str) -> PushDeviceSingleResponse:
        """GET /v1/push/devices/:id."""
        return self._client._request("GET", f"/push/devices/{device_id}")

    def delete(self, device_id: str) -> Dict[str, Any]:
        """DELETE /v1/push/devices/:id."""
        return self._client._request("DELETE", f"/push/devices/{device_id}")


class PushMessagesNamespace:
    """POST/GET /v1/push/messages, GET /v1/push/messages/:id, POST /v1/push/messages/:id/cancel."""

    def __init__(self, client: "Notifique") -> None:
        self._client = client

    def send(
        self,
        params: Union[SendPushParams, Dict[str, Any]],
    ) -> SendPushResponse:
        """POST /v1/push/messages — Envia notificações push."""
        return self._client._request("POST", "/push/messages", json=params)

    def list(
        self,
        params: Optional[Dict[str, Any]] = None,
    ) -> PushMessageListResponse:
        """GET /v1/push/messages."""
        return self._client._request("GET", "/push/messages", params=params or {})

    def get(self, message_id: str) -> PushMessageSingleResponse:
        """GET /v1/push/messages/:id."""
        return self._client._request("GET", f"/push/messages/{message_id}")

    def cancel(self, message_id: str) -> CancelPushResponse:
        """POST /v1/push/messages/:id/cancel."""
        return self._client._request("POST", f"/push/messages/{message_id}/cancel")


class PushNamespace:
    """Push API: apps, devices, messages."""

    def __init__(self, client: "Notifique") -> None:
        self._client = client
        self.apps = PushAppsNamespace(client)
        self.devices = PushDevicesNamespace(client)
        self.messages = PushMessagesNamespace(client)


class Notifique:
    """
    Cliente oficial Notifique para Python.
    - whatsapp: envio, listagem, status, editar, apagar, cancelar, instâncias, QR
    - sms: send, get, cancel
    - email: send, get, cancel, domains (list, create, get, verify)
    - push: apps, devices, messages
    - messages: send (template multi-canal)
    """

    def __init__(
        self,
        api_key: str,
        base_url: str = "https://api.notifique.dev/v1",
    ) -> None:
        self.api_key = api_key
        self.base_url = base_url.rstrip("/")
        self.whatsapp = WhatsAppNamespace(self)
        self.sms = SmsNamespace(self)
        self.email = EmailNamespace(self)
        self.email.domains = EmailDomainsNamespace(self)  # type: ignore
        self.messages = MessagesNamespace(self)
        self.push = PushNamespace(self)

    def _request(
        self,
        method: str,
        path: str,
        **kwargs: Any,
    ) -> Any:
        url = f"{self.base_url}{path}"
        headers = kwargs.pop("headers", {})
        headers.update(
            {
                "Authorization": f"Bearer {self.api_key}",
                "Content-Type": "application/json",
                "User-Agent": "Notifique-Python-SDK/0.2.0",
            }
        )
        response = requests.request(method, url, headers=headers, **kwargs)
        if not response.ok:
            try:
                data = response.json()
            except Exception:
                data = {}
            msg = (
                data.get("message")
                if isinstance(data, dict) and isinstance(data.get("message"), str)
                else (response.reason or f"{response.status_code}")
            )
            details = data.get("details") if isinstance(data, dict) and isinstance(data.get("details"), list) else None
            if details:
                parts = [f"{d.get('field', '')}: {d.get('message', '')}".strip() for d in details if isinstance(d, dict)]
                if parts:
                    msg = f"{msg} ({'; '.join(parts)})"
            raise NotifiqueApiError(msg, response.status_code, response_data=data if isinstance(data, dict) else None)
        return response.json()
