package com.vo;

import java.time.ZonedDateTime;

public class Counter {
    private String ip;
    private String name;
    private Integer totalIn = 0;
    private Integer totalOut = 0;
    private String friendlyName = "";
    private ZonedDateTime lastUpdate;
    private String serial = "";

    public Counter(String ip, String name) {
        this.ip = ip;
        this.name = name;
    }

    public void update() {
        try {
            Response r = new FakeHttp().get("http://" + ip + "/local/people-counter/.api?live-sum.json");
            totalIn = r.in();
            totalOut = r.out();
            friendlyName = r.name();
            lastUpdate = r.timestamp();
            serial = r.serial();
        } catch (Exception e) {
            friendlyName = "error getting count from " + name;
        }
    }

    public String getIp() { return ip; }
    public String getName() { return name; }
    public Integer getTotalIn() { return totalIn; }
    public Integer getTotalOut() { return totalOut; }
    public String getFriendlyName() { return friendlyName; }
    public ZonedDateTime getLastUpdate() { return lastUpdate; }
    public String getSerial() { return serial; }
}


