using Xunit;

namespace Domain.Tests
{
    public class CurrentCountTest
    {
        [Fact]
        public void ShouldAddTwoCurrentCounts()
        {
            var actual = new CameraMeasurement(1, 1).Add(new CameraMeasurement(4, 1));
            Assert.Equal(new CameraMeasurement(5, 2).Total, actual.Total);
        }
    }
}