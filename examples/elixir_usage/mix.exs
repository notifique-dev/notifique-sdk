defmodule NotifiqueExample.MixProject do
  use Mix.Project

  def project do
    [
      app: :notifique_example,
      version: "0.1.0",
      elixir: "~> 1.14",
      start_permanent: Mix.env() == :prod,
      deps: deps()
    ]
  end

  defp deps do
    [
      {:notifique, path: "../../packages/sdk-elixir"}
    ]
  end
end
