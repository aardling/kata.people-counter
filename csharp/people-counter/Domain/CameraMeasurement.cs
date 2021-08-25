using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public record CameraMeasurement(int InAmount, int OutAmount)
    {
        public CameraMeasurement Add(CameraMeasurement other) =>
            new CameraMeasurement(this.InAmount + other.InAmount, this.OutAmount + other.OutAmount);

        public static CameraMeasurement Sum(IEnumerable<CameraMeasurement> all) =>
            all.Aggregate(new CameraMeasurement(0, 0), (sum, other) => sum.Add(other));

        public int Total => InAmount - OutAmount;
    }
}