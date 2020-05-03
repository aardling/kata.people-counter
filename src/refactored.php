<?php declare(strict_types=1);
Main::main1();

class Main
{
    public static function main1()
    {
        $httpClient = new HttpClient();
        $lobby = new Zone($httpClient, 'South Lobby', [
            new Camera('Camera1', '192.168.55.130'),
            new Camera('Camera2', '192.168.55.131'),
            new Camera('Camera3', '192.168.55.132'),
            new Camera('Camera4', '192.168.55.133'),
            new Camera('Camera5', '192.168.55.134'),
        ]);

        while (true) {
            $lobby->update();
            print "Lobby {$lobby->occupancy()}\n";
            sleep(1);
        }
    }
}

class Count
{
    private $in;
    private $out;

    function __construct($in, $out)
    {
        $this->in = $in;
        $this->out = $out;
    }

    public static function empty(): Count
    {
        return new Count(0, 0);
    }

    public function occupancy()
    {
        return $this->in - $this->out;
    }

    public function add(Count $c): Count
    {
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

class Camera
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

    function count() : Count
    {
        return $this->count;
    }


    function friendlyName(): string
    {
        return $this->friendly_name;
    }

}


class Zone
{
    private $name;
    private $cameras = [];
    private $httpClient;
    private Count $count;

    function __construct(HttpClient $httpClient, $name, $cameras)
    {
        $this->name = $name;
        $this->cameras = $cameras;
        $this->count = Count::empty();
        $this->httpClient = $httpClient;
    }

    public function update()
    {
        $this->count = Count::empty();
        foreach ($this->cameras as $camera) {
            $camera->update($this->httpClient);
            $this->count = $this->count->add($camera->count());
        }
    }


    function occupancy(): int
    {
        return $this->count->occupancy();
    }


}


class HttpClient
{
    function get()
    {
        return
            [
                'in' => random_int(0, 10),
                'out' => random_int(0, 10),
                'name' => "name" . random_int(0, 10),
                'timestamp' => "ts" . random_int(0, 10),
                'serial' => "serial" . random_int(0, 10),
            ];
    }
}