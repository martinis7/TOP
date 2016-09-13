using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratybos1
{
    class Interval
    {
        private readonly DateTime _from;
        private readonly DateTime _to;

        public Interval(DateTime from, DateTime to)
        {
            _from = from;
            _to = to;
        }

        public bool Contains(DateTime value)
        {
            return _from <= value && _to >= value;
        }

        //public bool Overlaps(Interval another)
        //{
        //
        //}
    }
}
