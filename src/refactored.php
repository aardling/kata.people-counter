<?php declare(strict_types=1);
Main::main1();
class Main
{
    public static function main1()
    {
        $httpClient = new HttpClient();
        $lobby = new Zone('South Lobby',
            [
                new Counter($httpClient, 'Camera1', '192.168.55.130'),
                new Counter($httpClient, 'Camera2', '192.168.55.131'),
                new Counter($httpClient, 'Camera3', '192.168.55.132'),
                new Counter($httpClient, 'Camera4', '192.168.55.133'),
                new Counter($httpClient, 'Camera5', '192.168.55.134'),
            ]);

        while(true) {
            $lobby->update();
            print "Lobby {$lobby->occupancy()}\n";
            sleep(1);
        }
    }
}


class Counter
{
    private $ip;
    private $name;
    private $total_in = 0;
    private $total_out = 0;
    private $friendly_name = "";
    private $last_udpate;
    private $serial;
    private $httpClient;

    function __construct($httpClient, $ip, $name)
    {
        $this->httpClient = $httpClient;
        $this->ip = $ip;
        $this->name = $name;
        $this->update();
    }

    public function update()
    {
        try {
            $data = $this->httpClient->get("http://{$this->ip}/people-counter/api/live.json");
            $this->total_in = $data['in'];
            $this->total_out = $data['out'];
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

    function __construct($name, $counters)
    {
        $this->name = $name;
        $this->counters = $counters;
        $this->update();
    }

    public function update()
    {
        $this->totalIn = 0;
        $this->totalOut = 0;
        foreach ($this->counters as $counter) {
            $counter->update();
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