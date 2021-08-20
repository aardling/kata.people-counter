package com.vo

data class CurrentCount(val inAmount : Int, val outAmount : Int) {
    val total get() = inAmount - outAmount

    fun add(other: CurrentCount) = CurrentCount(inAmount + other.inAmount, outAmount + other.outAmount)
}