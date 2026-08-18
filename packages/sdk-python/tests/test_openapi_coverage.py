"""Verify full OpenAPI operation coverage on the typed API surface."""

from __future__ import annotations

import json
from importlib import resources

from notifique.dynamic_api import to_snake
from notifique.generated.api import create_generated_api


class _MockHttp:
    def request(self, *args, **kwargs):
        return {"success": True}


def _load_operations() -> dict:
    raw = resources.files("notifique").joinpath("operations.json").read_text(encoding="utf-8")
    return json.loads(raw)


def _collect_generated_paths(node, prefix: str = "") -> list[str]:
    paths: list[str] = []
    for key in dir(node):
        if key.startswith("_"):
            continue
        value = getattr(node, key)
        if callable(value):
            paths.append(f"{prefix}{to_snake(key)}")
        elif value.__class__.__name__.endswith("Namespace"):
            paths.extend(_collect_generated_paths(value, f"{prefix}{key}."))
    return paths


def test_operations_registry_has_353_operations():
    data = _load_operations()
    assert data["count"] == 353
    assert len(data["operations"]) == 353


def test_typed_api_exposes_every_registry_operation():
    data = _load_operations()
    api = create_generated_api(_MockHttp())

    expected = [
        ".".join([*op["namespaces"], to_snake(op["methodName"])])
        for op in data["operations"]
    ]
    available = _collect_generated_paths(api)
    missing = sorted(set(expected) - set(available))
    assert missing == [], f"missing operations: {missing[:10]}{'...' if len(missing) > 10 else ''}"
    assert len(available) == 353
