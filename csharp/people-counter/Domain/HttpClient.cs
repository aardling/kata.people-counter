using System;

namespace Domain
{
    /* This class shouldn't be part of the domain, but of infrastructure
       To keep things small and easy we didn't do this
     */
    public class HttpClient
    {
        public HttpResponse Fetch(string url)
        {
            return new HttpResponse(10, 5, "some name", DateTime.Now, "xd13f0af");
        }
    }

    public record HttpResponse(int InAmount, int OutAmount, string Name, DateTime Timestamp, string Serial)
    {
        
    }
}
