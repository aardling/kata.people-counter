using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Zone
    {
        private readonly string _name;
        private readonly List<Camera> _cameras;
        private CurrentCount _currentCount;
        public int Occupancy => _currentCount.Total;

        public Zone(string name, List<Camera> cameras)
        {
            _name = name;
            _cameras = cameras;
            _currentCount = new CurrentCount(0, 0);
        }

        public void Update()
        {
            this._currentCount = this._cameras.Aggregate(new CurrentCount(0, 0),
                ((count, camera) => count.Add(camera.CurrentCount())));
        }
    }
}