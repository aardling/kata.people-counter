package com.vo

class Zone(private val name: String, private val cameras: Cameras) {
    private var currentCount = CurrentCount(0, 0)
    val occupancy get() = currentCount.total

    fun update() {
        val currentCameras = cameras.currentCameraStateForZone(name)
        currentCount = currentCameras.fold(CurrentCount(0, 0)) {currentCount, camera ->
            currentCount.add(camera.currentCount)
        }
    }
}