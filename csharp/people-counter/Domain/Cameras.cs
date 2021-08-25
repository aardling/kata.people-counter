using System.Linq;

namespace Domain
{
    public class Cameras
    {
        private readonly HttpClient _httpClient;

        public Cameras(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Occupancy GetFor(Zone zone)
        {
            var peopleFlows = zone.Cameras.Select(ForCamera);
            return Occupancy.CalculateBasedOne(peopleFlows);
        }

        private PeopleFlow ForCamera(Camera camera)
        {
            var data = this._httpClient.fetch("http://${camera.ip}/people-counter/api/live.json");
            return Camera.PeopleFlow(data);
        }
    }
}