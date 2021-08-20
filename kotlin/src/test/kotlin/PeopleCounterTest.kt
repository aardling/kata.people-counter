package com.vo

import org.junit.jupiter.api.Assertions.assertEquals
import org.junit.jupiter.api.Disabled
import org.junit.jupiter.api.Test

class PeopleCounterTest {

    @Test
    fun `should return correct occupancy`() {
        val httpClient = HttpClient()
        val cameras = Cameras(listOf(
            Camera(httpClient, "Camera1", "192.168.55.130"),
            Camera(httpClient, "Camera2", "192.168.55.131"),
            Camera(httpClient, "Camera3", "192.168.55.132"),
            Camera(httpClient, "Camera4", "192.168.55.133"),
            Camera(httpClient, "Camera5", "192.168.55.134")
        ))
        val lobby = Zone(
            "South Auditorium", cameras
        )

        lobby.update()
        assertEquals(lobby.occupancy, 25)
    }

    @Disabled
    @Test
    fun `should handle errors`() {}
}