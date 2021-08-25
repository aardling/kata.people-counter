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

        public Occupancy GetFor(Zone zone)
        {
            var peopleFlows = zone.Cameras.Select(ForCamera);
            return Occupancy.CalculateBasedOne(peopleFlows);
        }

        private CameraMeasurement ForCamera(Camera camera)
        {
            var data = this._httpClient.fetch("http://${camera.ip}/people-counter/api/live.json");
            return Camera.PeopleFlow(data);
        }
    }
}