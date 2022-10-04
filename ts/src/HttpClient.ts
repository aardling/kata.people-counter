export type Response = {
  inAmount: number;
  outAmount: number;
  name: string;
  timestamp: Date;
  serial: string;
};
export class HttpClient {
  fetch(_url: string) {
    return {
      inAmount: 10,
      outAmount: 5,
      name: "Foo",
      timestamp: new Date(),
      serial: "xd13f0af",
    };
  }
}
