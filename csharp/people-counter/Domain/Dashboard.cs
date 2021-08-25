using System;

namespace Domain
{
    public class Dashboard
    {
        private readonly Cameras _cameras;

        public Dashboard(Cameras cameras)
        {
            _cameras = cameras;
        }

        public void Show(Zone zone)
        {
            var occupancy = this._cameras.GetFor(zone);
            Console.WriteLine($"Total is: {occupancy.Total}");
        }
    }
}