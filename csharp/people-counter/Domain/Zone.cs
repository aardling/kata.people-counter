using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Zone
    {
        private readonly string _name;
        public readonly List<Camera> Cameras;

        public Zone(string name, List<Camera> cameras)
        {
            _name = name;
            Cameras = cameras;
        }
        
        public static int Occupancy(PeopleFlow peopleFlow) => peopleFlow.Total;
    }
}