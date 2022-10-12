defmodule Counter do
  def new(httpClient, name, ip) do
    state = %{
      httpClient: httpClient,
      name: name,
      ip: ip
    }

    update(state)
  end

  def update(counter) do
    %{httpClient: httpClient, ip: ip} = counter
    data = HttpClient.fetch(httpClient, "http://#{ip}/people-counter/api/live.json")

    Map.merge(
      counter,
      %{
        total_in: data.inAmount,
        total_out: data.outAmount,
        friendly_name: data.name,
        last_update: data.timestamp,
        serial: data.serial
      }
    )
  end
end
