using Xunit;

namespace Domain.Tests
{
    public class CameraMeasurementTest
    {
        [Fact]
        public void ShouldAddTwoMeasurements()
        {
            var actual = new CameraMeasurement(1, 1).Add(new CameraMeasurement(4, 1));
            Assert.Equal(new CameraMeasurement(5, 2).Total, actual.Total);
        }
    }
}