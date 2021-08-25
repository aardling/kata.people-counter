using System.Collections.Generic;

namespace Domain
{
    public record Zone(string Name, List<Camera> Cameras)
    {
        public static int Occupancy(CameraMeasurement cameraMeasurement) => cameraMeasurement.Total;
    }
}