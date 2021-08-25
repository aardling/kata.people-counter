using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public record Occupancy
    {
        public readonly int Total;

        private Occupancy(int total)
        {
            Total = total;
        }
        public static Occupancy From(IEnumerable<CameraMeasurement> measurements)
        {
            var total = measurements.Aggregate(0, (total, measurement) => total + (measurement.PeopleIn - measurement.PeopleOut));
            return new Occupancy(total);
        }
    }
}