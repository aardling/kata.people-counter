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
                    new Camera(httpClient, "Camera1", "192.168.55.130"),
                    new Camera(httpClient, "Camera2", "192.168.55.131"),
                    new Camera(httpClient, "Camera3", "192.168.55.132"),
                    new Camera(httpClient, "Camera4", "192.168.55.133"),
                    new Camera(httpClient, "Camera5", "192.168.55.134")
                }
            );

            lobby.Update();
            Assert.Equal(25, lobby.Occupancy);
        }
        
        [Fact]
        public void IfNothingChangesUpdatingShouldHaveNoEffect()
        {
            var httpClient = new HttpClient();
            var lobby = new Zone(
                "South Auditorium", new List<Camera> {
                    new Camera(httpClient, "Camera1", "192.168.55.130"),
                    new Camera(httpClient, "Camera2", "192.168.55.131"),
                    new Camera(httpClient, "Camera3", "192.168.55.132"),
                    new Camera(httpClient, "Camera4", "192.168.55.133"),
                    new Camera(httpClient, "Camera5", "192.168.55.134")
                }
            );

            lobby.Update();
            lobby.Update();
            Assert.Equal(25, lobby.Occupancy);
        }
    }
}
