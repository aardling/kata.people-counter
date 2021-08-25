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
            var occupancy = this._cameraMeasurements.GetFor(zone);
            Console.WriteLine($"Total is: {occupancy.Total}");
        }
    }
}