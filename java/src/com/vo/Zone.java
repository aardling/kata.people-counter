package com.vo;

import java.util.Set;

public class Zone
{
    private String name;
    private Set<Counter> counters;
    private Integer totalIn = 0;
    private Integer totalOut = 0;
    private Integer occupancy = 0;

    public Zone(String name, Set<Counter> counters) {
        this.name = name;
        this.counters = counters;
    }

    public void update() {
        totalIn = 0;
        totalOut = 0;
        for (Counter c : counters) {
            c.update();
            totalIn += c.getTotalIn();
            totalOut += c.getTotalOut();
        }
        occupancy = totalIn - totalOut;
    }



}
