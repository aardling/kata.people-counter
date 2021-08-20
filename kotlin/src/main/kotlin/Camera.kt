package com.vo

import java.time.ZonedDateTime

class Camera(private val httpClient: HttpClient, private val name: String, private val ip: String) {
    private var friendlyName = ""
    private var lastUpdate = ZonedDateTime.now()
    private var serial = ""
    var currentCount = CurrentCount(0, 0)

    init {
        update()
    }

    fun update() {
        try {
            val data = httpClient.fetch("http://${ip}/people-counter/api/live.json")
            currentCount = CurrentCount(data.inAmount, data.outAmount)
            friendlyName = data.name
            lastUpdate = data.timestamp
            serial = data.serial
        } catch (e: Exception) {
            friendlyName = "error connectiong to ${name}"
        }
    }


}