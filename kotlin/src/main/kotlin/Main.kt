package com.vo

fun main() {
    val httpClient = HttpClient()
    val lobby = Zone(
        "South Auditorium", listOf(
            Camera(httpClient, "Camera1", "192.168.55.130")
            ,  Camera(httpClient, "Camera2", "192.168.55.131")
            ,  Camera(httpClient, "Camera3",  "192.168.55.132")
            ,  Camera(httpClient, "Camera4", "192.168.55.133")
            ,  Camera(httpClient, "Camera5", "192.168.55.134")
        ))

    //while (true) {
    lobby.update()
    println("Lobby: ${lobby.occupancy}")
    //    Thread.sleep(1_000)
    //}
}