"""Build a nested API surface from operations.json at runtime."""

from __future__ import annotations

import json
import re
from importlib import resources
from typing import Any, Callable, Dict, List, Optional

from .http_transport import HttpTransport

_OPERATIONS_CACHE: Optional[Dict[str, Any]] = None


def to_snake(name: str) -> str:
    return re.sub(r"([A-Z])", r"_\1", name).replace("-", "_").lower().lstrip("_")


def _load_operations() -> Dict[str, Any]:
    global _OPERATIONS_CACHE
    if _OPERATIONS_CACHE is None:
        raw = resources.files("notifique").joinpath("operations.json").read_text(encoding="utf-8")
        _OPERATIONS_CACHE = json.loads(raw)
    return _OPERATIONS_CACHE


class DynamicNamespace:
    """Nested namespace node exposing callables and child namespaces."""

    def __init__(self) -> None:
        self.__dict__["_children"] = {}

    def __getattr__(self, name: str) -> Any:
        children = self.__dict__["_children"]
        if name in children:
            return children[name]
        raise AttributeError(f"{type(self).__name__!r} object has no attribute {name!r}")

    def __setattr__(self, name: str, value: Any) -> None:
        if name == "_children":
            self.__dict__[name] = value
        else:
            self.__dict__["_children"][name] = value

    def __dir__(self) -> List[str]:
        return sorted(self.__dict__["_children"].keys())

    def _iter_nodes(self) -> List[tuple[str, Any]]:
        out: List[tuple[str, Any]] = []
        for key, value in self.__dict__["_children"].items():
            if isinstance(value, DynamicNamespace):
                for child_key, child_value in value._iter_nodes():
                    out.append((f"{key}.{child_key}", child_value))
            else:
                out.append((key, value))
        return out


class DynamicApi(DynamicNamespace):
    """Root API object with attached HTTP transport."""

    def __init__(self, http: HttpTransport) -> None:
        super().__init__()
        self.http = http


def _make_operation(
    http: HttpTransport,
    http_method: str,
    url_template: str,
    path_param_names: List[str],
) -> Callable[..., Any]:
    has_path_params = bool(path_param_names)

    def operation(
        path_params: Optional[Dict[str, str]] = None,
        *,
        query: Optional[Dict[str, Any]] = None,
        body: Optional[Any] = None,
        idempotency_key: Optional[str] = None,
        **kwargs: Any,
    ) -> Any:
        resolved_path_params = dict(path_params or {})
        if kwargs:
            resolved_path_params.update(kwargs)
        if has_path_params and not resolved_path_params:
            missing = ", ".join(path_param_names)
            raise TypeError(f"missing required path_params: {missing}")
        return http.request(
            http_method,
            url_template,
            query=query,
            body=body,
            idempotency_key=idempotency_key,
            path_params=resolved_path_params or None,
        )

    if has_path_params:
        operation.__doc__ = f"{http_method} {url_template}"
    else:
        operation.__doc__ = f"{http_method} {url_template}"

    return operation


def _get_or_create_namespace(root: DynamicNamespace, namespaces: List[str]) -> DynamicNamespace:
    node: DynamicNamespace = root
    for part in namespaces:
        children = node.__dict__["_children"]
        child = children.get(part)
        if not isinstance(child, DynamicNamespace):
            child = DynamicNamespace()
            children[part] = child
        node = child
    return node


def build_dynamic_api(http: HttpTransport) -> DynamicApi:
    """Build the full nested API from the bundled operations registry."""
    api = DynamicApi(http)
    data = _load_operations()
    for op in data["operations"]:
        namespaces = op["namespaces"]
        method_name = to_snake(op["methodName"])
        target = _get_or_create_namespace(api, namespaces)
        target.__dict__["_children"][method_name] = _make_operation(
            http,
            op["httpMethod"],
            op["urlTemplate"],
            list(op.get("pathParams") or []),
        )
    return api


def collect_method_paths(node: Any, prefix: str = "") -> List[str]:
    """Collect dotted paths for every callable on the dynamic API tree."""
    paths: List[str] = []
    if isinstance(node, DynamicNamespace):
        for key, value in node._iter_nodes():
            full = f"{prefix}.{key}" if prefix else key
            if callable(value):
                paths.append(full)
            else:
                paths.extend(collect_method_paths(value, full))
    return paths
