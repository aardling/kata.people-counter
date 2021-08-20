package com.vo

import org.junit.jupiter.api.Assertions.assertEquals
import org.junit.jupiter.api.Test

class PeopleCounterTest {

    @Test
    fun `should return correct occupancy`() {
        val httpClient = HttpClient()
        val lobby = Zone(
            "South Auditorium", listOf(
                Counter(httpClient, "Camera1", "192.168.55.130"),
                Counter(httpClient, "Camera2", "192.168.55.131"),
                Counter(httpClient, "Camera3", "192.168.55.132"),
                Counter(httpClient, "Camera4", "192.168.55.133"),
                Counter(httpClient, "Camera5", "192.168.55.134")
            )
        )

        lobby.update()
        assertEquals(lobby.occupancy, 25)
    }
}