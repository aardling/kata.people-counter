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
            var peopleFlow = this._cameras.Get(zone);
            Console.WriteLine("Total is: {peopleFlow.Total}");
        }
    }
}