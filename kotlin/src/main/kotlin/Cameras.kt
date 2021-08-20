package com.vo

class Cameras(private val cameras : List<Camera>) {
    fun currentCameraStateForZone(zoneName : String) = cameras
}