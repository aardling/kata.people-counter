defmodule PeopleCounterTest do
  use ExUnit.Case
  doctest PeopleCounter

  test "should return the correct occupancy" do
    httpClient = HttpClient.new()
    lobby = Zone.new("South Auditorium", [
    Counter.new(httpClient, "Camera1", "192.168.55.130"),
    Counter.new(httpClient, "Camera2", "192.168.55.131"),
    Counter.new(httpClient, "Camera3", "192.168.55.132"),
    Counter.new(httpClient, "Camera4", "192.168.55.133"),
    Counter.new(httpClient, "Camera5", "192.168.55.134"),
    ])
    lobby = Zone.update(lobby)

    assert Zone.occupancy(lobby) == 25
  end
end
