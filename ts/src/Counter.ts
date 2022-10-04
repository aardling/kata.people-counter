import { HttpClient } from "./HttpClient";

export default class Counter {
  httpClient: HttpClient;
  name: String;
  ip: String;
  friendlyName: string;
  totalIn: any;
  totalOut: any;
  lastUpdate: any;
  serial: any;
  constructor(httpClient: HttpClient, name: String, ip: String) {
    this.httpClient = httpClient;
    this.name = name;
    this.ip = ip;
    this.update();
  }
  update() {
    try {
      const data = this.httpClient.fetch(
        "http://${ip}/people-counter/api/live.json"
      );
      this.totalIn = data.inAmount;
      this.totalOut = data.outAmount;
      this.friendlyName = data.name;
      this.lastUpdate = data.timestamp;
      this.serial = data.serial;
    } catch (e) {
      this.friendlyName = "error connectiong to ${name}";
    }
  }
}
