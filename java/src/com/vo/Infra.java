package com.vo;


import java.time.ZonedDateTime;

class FakeHttp {
    public Response get(String Url) {
        return new Response();
    }
}

class Response {
    public Integer in(){};
    public Integer out(){};
    public String name(){};
    public ZonedDateTime timestamp(){};
    public String serial(){};

}
