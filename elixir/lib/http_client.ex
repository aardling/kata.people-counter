defmodule HttpClient do
  def new(), do: nil

  def fetch(_me, url) do
    %{
      inAmount: 10,
      outAmount: 5,
      name: "Foo",
      timestamp: DateTime.now("Etc/UTC"),
      serial: "xd13f0af",
    }
  end

end
