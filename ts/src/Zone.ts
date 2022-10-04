import Counter from "./Counter";

export default class Zone {
  name: string;
  counters: Counter[];
  occupancy: number;
  constructor(name: string, counters: Counter[]) {
    this.name = name;
    this.counters = counters;
    this.occupancy = 0;
  }
  update() {
    let totalIn = 0;
    let totalOut = 0;
    for (let counter of this.counters) {
      counter.update();
      totalIn += counter.totalIn;
      totalOut += counter.totalOut;
    }

    this.occupancy = totalIn - totalOut;
  }
}
