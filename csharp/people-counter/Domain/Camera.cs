using System;

namespace Domain
{
    public class Camera
    {
        private readonly HttpClient _httpClient;
        private readonly string _name;
        private readonly string _ip;

        public Camera(HttpClient httpClient, string name, string ip)
        {
            _httpClient = httpClient;
            _name = name;
            _ip = ip;
        }

        public PeopleFlow PeopleFlow()
        {
            var data = this._httpClient.fetch("http://${ip}/people-counter/api/live.json");
            return new PeopleFlow(data.InAmount, data.OutAmount);
        }
    }
}