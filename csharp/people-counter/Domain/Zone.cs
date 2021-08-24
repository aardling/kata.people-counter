using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Domain
{
    public class Zone
    {
        private readonly string _name;
        private readonly List<Camera> _counters;
        private CurrentCount _currentCount;
        public int Occupancy => _currentCount.Total;

        public Zone(string name, List<Camera> counters)
        {
            _name = name;
            _counters = counters;
            _currentCount = new CurrentCount(0, 0);
        }

        public void Update()
        {
            foreach (var camera in this._counters)
            {
                camera.Update();
                _currentCount = _currentCount.Add(camera.CurrentCount);
            }
        }
    }
}