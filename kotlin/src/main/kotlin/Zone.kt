package com.vo

class Zone(private val name: String, private val cameras: List<Camera>) {
    private var totalIn = 0
    private var totalOut = 0
    var occupancy = 0

    fun update() {
        totalIn = 0;
        totalOut = 0;
        for (counter in cameras) {
            counter.update()
            totalIn += counter.totalIn
            totalOut += counter.totalOut
        }
        occupancy = totalIn - totalOut
    }
}