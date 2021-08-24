using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Zone
    {
        private readonly string _name;
        private readonly List<Camera> _cameras;
        private PeopleFlow _peopleFlow;
        public int Occupancy => _peopleFlow.Total;

        public Zone(string name, List<Camera> cameras)
        {
            _name = name;
            _cameras = cameras;
            _peopleFlow = new PeopleFlow(0, 0);
        }

        public void Update()
        {
            this._peopleFlow = this._cameras.Aggregate(new PeopleFlow(0, 0),
                ((count, camera) => count.Add(camera.PeopleFlow())));
        }
    }
}