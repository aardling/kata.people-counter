from flask import Flask, render_template
from peoplecounter import Counter, Zone

app = Flask(__name__)


# counters = {'KT3': Counter('KT3', '192.168.71.168'),
#             'KT4': Counter('KT4', '192.168.71.167'),
#             'KT11': Counter('KT11', '192.168.71.165'),
#             'KT2': Counter('KT2', '192.168.71.163'),
#             'KT9': Counter('KT9', '192.168.71.162'),
#             'KT8': Counter('KT8', '192.168.71.161'),
#             'KT7': Counter('KT7', '192.168.71.160'),
#             'KT6': Counter('KT6', '192.168.71.159'),
#             'KT5': Counter('KT5', '192.168.71.158'),
#             'KT1': Counter('KT1', '192.168.71.135'),
#             'KT10': Counter('KT10', '192.168.71.164')}

voedingshal = Zone('Voedingshal', [Counter('KT1', '192.168.71.135'),
                                   Counter('KT3', '192.168.71.168'),
                                   Counter('KT4', '192.168.71.167'),
                                   Counter('KT9', '192.168.71.162'),
                                   Counter('KT10', '192.168.71.164')])

@app.route('/')
def people_counter():
    zone = voedingshal.get_dict()
    return render_template('counter.html',
                           zone=zone)
