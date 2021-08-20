package com.vo

import java.time.ZonedDateTime

class Camera(private val httpClient: HttpClient, private val name: String, private val ip: String) {
    var totalIn = 0
    var totalOut = 0
    private var friendlyName = ""
    private var lastUpdate = ZonedDateTime.now()
    private var serial = ""

    init {
        update()
    }

    fun update() {
        try {
            val data = httpClient.fetch("http://${ip}/people-counter/api/live.json")
            totalIn = data.inAmount
            totalOut = data.outAmount
            friendlyName = data.name
            lastUpdate = data.timestamp
            serial = data.serial
        } catch (e: Exception) {
            friendlyName = "error connectiong to ${name}"
        }
    }


}