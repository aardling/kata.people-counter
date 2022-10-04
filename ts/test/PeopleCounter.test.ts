import { describe, expect, test } from "@jest/globals";
import Counter from "../src/Counter";
import { HttpClient } from "../src/HttpClient";
import Zone from "../src/Zone";

test("should return correct occupancy", () => {
  const httpClient = new HttpClient();
  const lobby = new Zone("South Auditorium", [
    new Counter(httpClient, "Camera1", "192.168.55.130"),
    new Counter(httpClient, "Camera2", "192.168.55.131"),
    new Counter(httpClient, "Camera3", "192.168.55.132"),
    new Counter(httpClient, "Camera4", "192.168.55.133"),
    new Counter(httpClient, "Camera5", "192.168.55.134"),
  ]);
  lobby.update();
  expect(lobby.occupancy).toBe(25);
});
