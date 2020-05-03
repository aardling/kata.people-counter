import requests


class Counter(object):
    """Class representing a counter."""

    def __init__(self, name, ip):
        self.ip = ip
        self.name = name
        self.total_in = 0
        self.total_out = 0
        self.friendly_name = ''
        self.last_update = ''
        self.serial = ''
        self.update()

    def update(self):
        try:
            r = requests.get('http://'
                             + self.ip
                             + '/local/people-counter/.api?live-sum.json',
                             timeout=1)
            data = r.json()
            self.total_in = data['in']
            self.total_out = data['out']
            self.friendly_name = data['name']
            self.last_update = data['timestamp']
            self.serial = data['serial']
        except:
            self.friendly_name = "error getting count from " + self.name

    def get_dict(self):
        return {'name': self.friendly_name,
                'in': self.total_in,
                'out': self.total_out}


class Zone(object):
    """Class representing a zone.
    A zone is monitored by one or more counters.
    """

    def __init__(self, name, counters):
        self.name = name
        self.counters = counters
        self.total_in = 0
        self.total_out = 0
        self.occupancy = 0
        self.update()

    def update(self):
        self.total_in = 0
        self.total_out = 0
        for c in self.counters:
            c.update()
            self.total_in += c.total_in
            self.total_out += c.total_out
        self.occupancy = self.total_in - self.total_out

    def get_dict(self):
        self.update()
        counter_dicts = []
        for c in self.counters:
            counter_dicts.append(c.get_dict())
        return {'name': self.name,
                'in': self.total_in,
                'out': self.total_out,
                'occupancy': self.occupancy,
                'counters': counter_dicts}
