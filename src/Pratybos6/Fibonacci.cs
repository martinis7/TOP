using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratybos6
{
    public class Fibonacci : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new FibonacciEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class FibonacciEnumerator : IEnumerator<int>
        {
            private int _last = 0;
            private int _current = 1;

            public int Current
            {
                get
                {
                    return _current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                var temp = _last;
                _last = _current;
                _current += temp;
                return true;
            }

            public void Reset()
            {
            }
        }
    }

    public static class Sequences
    {
        public static IEnumerable<int> Fibonacci()
        {
            var current = 1;
            var last = 0;
            
            while (true)
            {
                var temp = last;
                last = current;
                current += temp;

                yield return current;
            }
        }
    }
}
