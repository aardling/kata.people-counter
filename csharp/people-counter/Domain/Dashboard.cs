using System;

namespace Domain
{
    public class Dashboard
    {
        private readonly CameraMeasurements _cameraMeasurements;

        public Dashboard(CameraMeasurements cameraMeasurements)
        {
            _cameraMeasurements = cameraMeasurements;
        }

        public void Show(Zone zone)
        {
            var measurements = this._cameraMeasurements.ForZone(zone);
            var occupancy = Occupancy.From(measurements);
            Console.WriteLine($"Total is: {occupancy.Total}");
        }
    }
}