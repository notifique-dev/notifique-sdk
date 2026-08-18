"""HTTP transport for the generated OpenAPI client."""

from __future__ import annotations

import re
from typing import Any, Dict, Optional
from urllib.parse import quote, urlparse

import requests

DEFAULT_BASE_URL = "https://api.notifique.dev"
USER_AGENT = "Notifique-Python-SDK/0.2.0"


def normalize_base_url(base_url: Optional[str]) -> str:
    """Strip trailing /v1 from base URL; default to production API host."""
    url = (base_url or DEFAULT_BASE_URL).rstrip("/")
    url = re.sub(r"/v1/?$", "", url)
    return url


def _assert_secure_base_url(base_url: str) -> None:
    parsed = urlparse(base_url)
    if parsed.scheme != "https" or not parsed.netloc:
        raise ValueError("base_url must be an absolute HTTPS URL")


def _build_url(url_template: str, path_params: Optional[Dict[str, str]] = None) -> str:
    url = url_template
    if path_params:
        for key, value in path_params.items():
            url = url.replace(f"{{{key}}}", quote(str(value), safe=""))
    return url


class HttpTransport:
    """Low-level HTTP client used by the dynamic OpenAPI surface."""

    def __init__(
        self,
        *,
        api_key: Optional[str] = None,
        base_url: Optional[str] = None,
        timeout: int = 30,
        allow_anonymous: bool = False,
    ) -> None:
        key = (api_key or "").strip()
        if not allow_anonymous and not key:
            raise ValueError("api_key must be a non-empty string")

        normalized = normalize_base_url(base_url)
        _assert_secure_base_url(normalized)
        self._base_url = normalized
        self._timeout = timeout
        self._session = requests.Session()
        headers: Dict[str, str] = {
            "Content-Type": "application/json",
            "User-Agent": USER_AGENT,
        }
        if key:
            headers["Authorization"] = f"Bearer {key}"
        self._session.headers.update(headers)

    def close(self) -> None:
        self._session.close()

    def request(
        self,
        method: str,
        url_template: str,
        *,
        query: Optional[Dict[str, Any]] = None,
        body: Optional[Any] = None,
        idempotency_key: Optional[str] = None,
        path_params: Optional[Dict[str, str]] = None,
        headers: Optional[Dict[str, str]] = None,
    ) -> Any:
        url = f"{self._base_url}{_build_url(url_template, path_params)}"
        req_headers: Dict[str, str] = dict(headers or {})
        if idempotency_key:
            req_headers["Idempotency-Key"] = idempotency_key
            req_headers["x-idempotency-key"] = idempotency_key

        kwargs: Dict[str, Any] = {"timeout": self._timeout}
        if query is not None:
            kwargs["params"] = query
        if body is not None:
            kwargs["json"] = body
        if req_headers:
            kwargs["headers"] = req_headers

        response = self._session.request(method.upper(), url, **kwargs)
        if not response.ok:
            try:
                data: Any = response.json()
            except Exception:
                data = {}
            if isinstance(data, dict):
                msg: str = (
                    data.get("message")
                    if isinstance(data.get("message"), str)
                    else (response.reason or str(response.status_code))
                )
                details = data.get("details") if isinstance(data.get("details"), list) else None
                if details:
                    parts = [
                        f"{d.get('field', '')}: {d.get('message', '')}".strip()
                        for d in details
                        if isinstance(d, dict)
                    ]
                    if parts:
                        msg = f"{msg} ({'; '.join(parts)})"
            else:
                msg = response.reason or str(response.status_code)
                data = {}
            from .client import NotifiqueApiError

            raise NotifiqueApiError(
                msg,
                response.status_code,
                response_data=data if isinstance(data, dict) else None,
            )
        return response.json()


def create_http_transport(
    *,
    api_key: Optional[str] = None,
    base_url: Optional[str] = None,
    timeout: int = 30,
    allow_anonymous: bool = False,
) -> HttpTransport:
    return HttpTransport(
        api_key=api_key,
        base_url=base_url,
        timeout=timeout,
        allow_anonymous=allow_anonymous,
    )
