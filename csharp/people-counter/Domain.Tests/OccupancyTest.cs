using System.Collections.Generic;
using Xunit;

namespace Domain.Tests
{
    public class OccupancyTest
    {
        [Fact]
        public void ShouldCalculateTotals()
        {
            var actual = Occupancy.From(new List<CameraMeasurement>()
                {new CameraMeasurement(4, 1), new CameraMeasurement(1, 1)});

            var expected = Occupancy.From(new List<CameraMeasurement>() {new CameraMeasurement(3, 0)});

            Assert.Equal(expected, actual);
        }
    }
}