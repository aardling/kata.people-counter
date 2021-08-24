using Xunit;

namespace Domain.Tests
{
    public class CurrentCountTest
    {
        [Fact]
        public void ShouldAddTwoCurrentCounts()
        {
            var actual = new CurrentCount(1, 1).Add(new CurrentCount(4, 1));
            Assert.Equal(new CurrentCount(5, 2), actual);
        }
    }
}