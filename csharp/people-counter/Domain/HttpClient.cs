using System;

namespace Domain
{
    public class HttpClient
    {
        public HttpResponse fetch(string url)
        {
            return new HttpResponse(10, 5, "some name", DateTime.Now, "xd13f0af");
        }
    }

    public record HttpResponse(int InAmount, int OutAmount, string Name, DateTime Timestamp, string Serial)
    {
        
    }
}
