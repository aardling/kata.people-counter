using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public record CameraMeasurement(int PeopleIn, int PeopleOut)
    {
        public CameraMeasurement Add(CameraMeasurement other) =>
            new CameraMeasurement(this.PeopleIn + other.PeopleIn, this.PeopleOut + other.PeopleOut);

        public static CameraMeasurement Sum(IEnumerable<CameraMeasurement> all) =>
            all.Aggregate(new CameraMeasurement(0, 0), (sum, other) => sum.Add(other));

        public int Total => PeopleIn - PeopleOut;
    }
}