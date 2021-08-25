using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class CameraMeasurements
    {
        private readonly HttpClient _httpClient;

        public CameraMeasurements(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<CameraMeasurement> ForZone(Zone zone) => zone.Cameras.Select(ForCamera);

        public CameraMeasurement ForCamera(Camera camera)
        {
            var data = this._httpClient.Fetch("http://${camera.ip}/people-counter/api/live.json");
            return new CameraMeasurement(data.InAmount, data.OutAmount);
        }
    }
}