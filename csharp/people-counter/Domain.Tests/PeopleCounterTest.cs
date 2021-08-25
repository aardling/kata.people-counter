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
                "South Auditorium", new List<Camera> {
                    new Camera("Camera1", "192.168.55.130"),
                    new Camera("Camera2", "192.168.55.131"),
                    new Camera("Camera3", "192.168.55.132"),
                    new Camera("Camera4", "192.168.55.133"),
                    new Camera("Camera5", "192.168.55.134")
                }
            );

            var cameras = new Cameras(httpClient);
            var occupancy = cameras.GetFor(lobby);

            Assert.Equal(25, occupancy.Total);
        }
    }
}
