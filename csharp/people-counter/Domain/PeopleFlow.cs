using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public record PeopleFlow(int InAmount, int OutAmount)
    {
        public PeopleFlow Add(PeopleFlow other) =>
            new PeopleFlow(this.InAmount + other.InAmount, this.OutAmount + other.OutAmount);

        public static PeopleFlow Sum(IEnumerable<PeopleFlow> all) =>
            all.Aggregate(new PeopleFlow(0, 0), (sum, other) => sum.Add(other));

        public int Total => InAmount - OutAmount;
    }
}