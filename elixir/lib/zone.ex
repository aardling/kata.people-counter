defmodule Zone do
  def new(name, counters) do
    %{name: name, counters: counters, occupancy: 0}
  end

  def update(state) do
    counters = Enum.map(state.counters, fn counter -> Counter.update(counter) end)
    total_in = Enum.reduce(state.counters, 0, fn counter, acc ->
      acc + counter.total_in
    end)
    total_out = Enum.reduce(state.counters, 0, fn counter, acc ->
      acc + counter.total_out
    end)
    %{state | occupancy: total_in - total_out, counters: counters}
  end

  def occupancy(state), do: state.occupancy
end
