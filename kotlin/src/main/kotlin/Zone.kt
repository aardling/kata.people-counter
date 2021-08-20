package com.vo

class Zone(private val name: String, private val cameras: List<Camera>) {
    private var currentCount = CurrentCount(0, 0)
    val occupancy get() = currentCount.total

    fun update() {
        currentCount = cameras.fold(CurrentCount(0, 0)) {currentCount, camera ->
            currentCount.add(camera.currentCount)
        }
    }
}