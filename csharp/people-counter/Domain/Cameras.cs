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

        public PeopleFlow Get(Zone zone)
        {
            var forCameras = zone.Cameras.Select(ForCamera);
            return PeopleFlow.Sum(forCameras);
        }

        private PeopleFlow ForCamera(Camera camera)
        {
            var data = this._httpClient.fetch("http://${camera.ip}/people-counter/api/live.json");
            return Camera.PeopleFlow(data);
        }
    }
}