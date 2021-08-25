using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public record Occupancy(int Total)
    {
        public static Occupancy CalculateBasedOne(IEnumerable<CameraMeasurement> peopleFlows) => new Occupancy(CameraMeasurement.Sum(peopleFlows).Total);
    }
}