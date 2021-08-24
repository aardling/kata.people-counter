using System.Collections.Generic;
using Domain;
using Xunit;

namespace Domain.Tests
{
    public class PeopleCounterTest
    {
        [Fact]
        public void ShouldReturnCorrectOccupancy()
        {
            var httpClient = new HttpClient();
            var lobby = new Zone(
                "South Auditorium", new List<Counter> {
                    new Counter(httpClient, "Camera1", "192.168.55.130"),
                    new Counter(httpClient, "Camera2", "192.168.55.131"),
                    new Counter(httpClient, "Camera3", "192.168.55.132"),
                    new Counter(httpClient, "Camera4", "192.168.55.133"),
                    new Counter(httpClient, "Camera5", "192.168.55.134")
                }
            );

            lobby.update();
            Assert.Equal(lobby.occupancy, 25);
        }
    }
}
