using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratybos4
{
    //do NOT do this! this violates the commutativity rule and will not work on all sorting algorithms
    public class ShuffleComparer<T> : IComparer<T>
    {
        private readonly Random _random = new Random();

        public int Compare(T x, T y)
        {
            if (_random.NextDouble() > 0.5) return 1;
            return -1;
        }
    }
}
