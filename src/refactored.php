<?php declare(strict_types=1);
Main::main1();
class Main
{
    public static function main1()
    {
        $httpClient = new HttpClient();
        $lobby = new Zone($httpClient, 'South Lobby', [
            new Counter('Camera1', '192.168.55.130'),
            new Counter('Camera2', '192.168.55.131'),
            new Counter('Camera3', '192.168.55.132'),
            new Counter('Camera4', '192.168.55.133'),
            new Counter('Camera5', '192.168.55.134'),
        ]);

        while(true) {
            $lobby->update();
            print "Lobby {$lobby->occupancy()}\n";
            sleep(1);
        }
    }
}

class Count {
    private $in;
    private $out;

    function __construct($in, $out)
    {
        $this->in = $in;
        $this->out = $out;
    }

    public function occupancy()
    {
        return $this->in - $this->out;
    }

    public function add(Count $c):Count {
     return new Count($this->in + $c->in, $this->out + $c->out);
    }

    function in()
    {
        return $this->in;
    }

    function out()
    {
        return $this->out;
    }


}
class Counter
{
    private $ip;
    private $name;
    private $count;
    private $friendly_name = "";
    private $last_udpate;
    private $serial;

    function __construct($ip, $name)
    {
        $this->ip = $ip;
        $this->name = $name;
    }

    public function update(HttpClient $httpClient)
    {
        try {
            $data = $httpClient->get("http://{$this->ip}/people-counter/api/live.json");
            $this->count = new Count($data['in'], $data['out']);
            $this->friendly_name = $data['name'];
            $this->last_udpate = $data['timestamp'];
            $this->serial = $data['serial'];
        } catch (Exception $e) {
            $this->$this->friendly_name = "error connecting to {$this->name}";
        }
    }

    function totalIn(): int
    {
        return $this->total_in;
    }

    function totalOut(): int
    {
        return $this->total_out;
    }

    function triendlyName(): string
    {
        return $this->friendly_name;
    }

}


class Zone
{
    private $name;
    private $counters = [];
    private $totalIn = 0;
    private $totalOut = 0;
    private $occupancy = 0;
    private $httpClient;

    function __construct(HttpClient $httpClient, $name, $counters)
    {
        $this->name = $name;
        $this->counters = $counters;
        $this->httpClient = $httpClient;
    }

    public function update()
    {
        $this->totalIn = 0;
        $this->totalOut = 0;
        /** @var Counter $counter */
        foreach ($this->counters as $counter) {
            $counter->update($this->httpClient);
            $this->totalIn += $counter->totalIn();
            $this->totalOut += $counter->totalOut();
        }
        $this->occupancy = $this->totalIn - $this->totalOut;
    }

    function counters(): array
    {
        return $this->counters;
    }

    function totalIn(): int
    {
        return $this->totalIn;
    }

    function totalOut(): int
    {
        return $this->totalOut;
    }

    function occupancy(): int
    {
        return $this->occupancy;
    }


}



class HttpClient
{
    function get() {
        return
            [
                'in' => random_int(0, 10),
                'out' => random_int(0, 10),
                'name' => "name".random_int(0, 10),
                'timestamp' => "ts".random_int(0, 10),
                'serial' => "serial".random_int(0, 10),
                ];
    }
}