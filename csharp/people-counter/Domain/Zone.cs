using System.Collections.Generic;
using System.Linq;
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
            this._currentCount = this._counters.Aggregate(new CurrentCount(0, 0), ((count, camera) =>
            {
                camera.Update();
                return count.Add(camera.CurrentCount);
            }));
        }
    }
}