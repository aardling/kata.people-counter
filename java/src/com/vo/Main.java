package com.vo;

import java.util.HashSet;
import java.util.Set;

public class Main {

    public static void main(String[] args) {

        Set<Counter> counters = new HashSet<>();
        counters.add(new Counter("KT1", "192.168.71.135"));
        counters.add(new Counter("KT3", "192.168.71.168"));
        counters.add(new Counter("KT4", "192.168.71.167"));
        counters.add(new Counter("KT9", "192.168.71.162"));
        counters.add(new Counter("KT10", "192.168.71.164"));

        Zone mainHall = new Zone("Main Hall", counters);


        // every minute:
        mainHall.update();
        // render html table
    }
}
