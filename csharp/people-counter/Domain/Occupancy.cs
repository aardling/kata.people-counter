using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public record Occupancy(int Total)
    {
        public static Occupancy CalculateBasedOne(IEnumerable<PeopleFlow> peopleFlows) => new Occupancy(PeopleFlow.Sum(peopleFlows).Total);
    }
}