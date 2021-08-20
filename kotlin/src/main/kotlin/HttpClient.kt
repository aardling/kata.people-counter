package com.vo

import java.time.ZonedDateTime

data class Response(val inAmount: Int, val outAmount: Int, val name: String, val timestamp: ZonedDateTime, val serial: String)

class HttpClient {
    fun fetch(url : String) = Response(10, 5, "foo", ZonedDateTime.now(), "xd13f0af")
}