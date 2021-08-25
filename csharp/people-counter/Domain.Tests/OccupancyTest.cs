using System.Collections.Generic;
using Xunit;

namespace Domain.Tests
{
    public class OccupancyTest
    {
        [Fact]
        public void ShouldCalculateTotals()
        {
            var occupancy = Occupancy.From(new List<CameraMeasurement>()
                {new CameraMeasurement(4, 1), new CameraMeasurement(1, 1)});

            Assert.Equal(new Occupancy(3), occupancy);
        }
    }
}