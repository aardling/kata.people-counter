import unittest
import responses
from app.peoplecounter import Counter


class TestCounter(unittest.TestCase):

    @responses.activate
    def test_Counter_init(self):
        json = {'in': 1,
                'out': 2,
                'name': 'Test counter name',
                'timestamp': 123,
                'serial': '123cxwwd'}

        responses.add(responses.GET,
                      'http://123.123.123.123/local/people-counter/.api?live-sum.json',
                      json=json)
        a_test_counter = Counter('Testcounter', '123.123.123.123')

        self.assertEqual(a_test_counter.total_in, json['in'])
        self.assertEqual(a_test_counter.total_out, json['out'])
        self.assertEqual(a_test_counter.friendly_name, json['name'])
        self.assertEqual(a_test_counter.last_update, json['timestamp'])
        self.assertEqual(a_test_counter.serial, json['serial'])

    @responses.activate
    def test_Counter_update(self):
        json = [{'in': 1,
                 'out': 2},
                {'in': 3,
                 'out': 1}]

        responses.add(responses.GET,
                      'http://123.123.123.123/local/people-counter/.api?live-sum.json',
                      json=json[0])
        responses.add(responses.GET,
                      'http://123.123.123.123/local/people-counter/.api?live-sum.json',
                      json=json[1])
        a_test_counter = Counter('Testcounter', '123.123.123.123')

        self.assertEqual(a_test_counter.total_in, json[0]['in'])
        self.assertEqual(a_test_counter.total_out, json[0]['out'])

        a_test_counter.update()

        self.assertEqual(a_test_counter.total_in, json[1]['in'])
        self.assertEqual(a_test_counter.total_out, json[1]['out'])
