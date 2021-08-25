using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public record Zone(string Name, List<Camera> Cameras)
    {
        public static int Occupancy(CameraMeasurement cameraMeasurement) => cameraMeasurement.Total;
    }
}