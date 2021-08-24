using Xunit;

namespace Domain.Tests
{
    public class CurrentCountTest
    {
        [Fact]
        public void ShouldAddTwoCurrentCounts()
        {
            var actual = new PeopleFlow(1, 1).Add(new PeopleFlow(4, 1));
            Assert.Equal(new PeopleFlow(5, 2).Total, actual.Total);
        }
    }
}