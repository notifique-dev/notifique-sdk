defmodule Notifique.OpenApiCoverageTest do
  use ExUnit.Case

  alias Notifique.DynamicApi

  test "registry has 353 operations" do
    assert DynamicApi.count() == 353
    assert length(DynamicApi.operation_paths()) == 353
  end

  test "dynamic api exposes every registry operation" do
    client = Notifique.new("test-key")
    api = Notifique.dynamic_api(client)

    missing =
      DynamicApi.operation_paths()
      |> Enum.reject(fn path ->
        path
        |> String.split(".")
        |> operation_exists?(api)
      end)

    assert missing == []
  end

  test "typed api exposes namespace accessors" do
    client = Notifique.new("test-key")
    typed = Notifique.api(client)

    assert %Notifique.TypedApi{} = typed
    assert %Notifique.TypedApi.Campaigns{} = Notifique.TypedApi.campaigns(typed)
    assert %Notifique.TypedApi.WellKnown{} = Notifique.TypedApi.well_known(typed)
  end

  test "top-level namespaces include wellKnown and oauth" do
    namespaces = DynamicApi.top_level_namespaces()
    assert "wellKnown" in namespaces
    assert "oauth" in namespaces
    assert "whatsapp" in namespaces
  end

  defp operation_exists?([method], api) do
    is_function(Map.get(api, method))
  end

  defp operation_exists?([namespace | rest], api) do
    case Map.get(api, namespace) do
      %{} = child -> operation_exists?(rest, child)
      _ -> false
    end
  end
end
