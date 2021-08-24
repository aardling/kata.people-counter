using System.Collections.Generic;

namespace Domain
{
    public class Zone
    {
        private readonly string _name;
        private readonly List<Camera> _counters;
        public int occupancy;
        private int _totalIn;
        private int _totalOut;

        public Zone(string name, List<Camera> counters)
        {
            _name = name;
            _counters = counters;
        }

        public void update()
        {
            this._totalIn = 0;
            this._totalOut = 0;
            foreach (var camera in this._counters)
            {
                camera.Update();
                this._totalIn += camera.TotalIn;
                this._totalOut += camera.TotalOut;
                
            }

            this.occupancy = this._totalIn - this._totalOut;
        }
    }
}