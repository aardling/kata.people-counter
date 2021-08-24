using System.Collections.Generic;

namespace Domain
{
    public class Zone
    {
        private readonly string _name;
        private readonly List<Counter> _counters;
        public int occupancy;
        private int _totalIn;
        private int _totalOut;

        public Zone(string name, List<Counter> counters)
        {
            _name = name;
            _counters = counters;
        }

        public void update()
        {
            this._totalIn = 0;
            this._totalOut = 0;
            foreach (var counter in this._counters)
            {
                counter.Update();
                this._totalIn += counter.TotalIn;
                this._totalOut += counter.TotalOut;
                
            }

            this.occupancy = this._totalIn - this._totalOut;
        }
    }
}