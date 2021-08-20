package com.vo

fun main() {
    val httpClient = HttpClient()
    val lobby = Zone(
        "South Auditorium", listOf(
            Counter(httpClient, "Camera1", "192.168.55.130")
            ,  Counter(httpClient, "Camera2", "192.168.55.131")
            ,  Counter(httpClient, "Camera3",  "192.168.55.132")
            ,  Counter(httpClient, "Camera4", "192.168.55.133")
            ,  Counter(httpClient, "Camera5", "192.168.55.134")
        ))

    //while (true) {
    lobby.update()
    println("Lobby: ${lobby.occupancy}")
    //    Thread.sleep(1_000)
    //}
}