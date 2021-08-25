using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public record Occupancy(int Total)
    {
        public static Occupancy From(IEnumerable<CameraMeasurement> measurements) =>
            new Occupancy(CameraMeasurement.Sum(measurements).Total);
    }
}