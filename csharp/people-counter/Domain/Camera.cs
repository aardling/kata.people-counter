using System;

namespace Domain
{
    public record Camera(string Name, string Ip)
    {
        public static CameraMeasurement PeopleFlow(HttpResponse response)
        {
            return new CameraMeasurement(response.InAmount, response.OutAmount);
        }
    }
}