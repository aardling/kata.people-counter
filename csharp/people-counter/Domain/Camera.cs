using System;

namespace Domain
{
    public class Camera
    {
        private readonly string _name;
        public readonly string Ip;

        public Camera(HttpClient httpClient, string name, string ip)
        {
            _name = name;
            Ip = ip;
        }

        public static PeopleFlow PeopleFlow(HttpResponse response)
        {
            return new PeopleFlow(response.InAmount, response.OutAmount);
        }
    }
}