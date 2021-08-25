using System;

namespace Domain
{
    public record Camera(string Name, string Ip)
    {
        public static PeopleFlow PeopleFlow(HttpResponse response)
        {
            return new PeopleFlow(response.InAmount, response.OutAmount);
        }
    }
}