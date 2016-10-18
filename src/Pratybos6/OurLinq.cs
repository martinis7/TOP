using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratybos6
{
    public class WhereEnumerable<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _seq;
        private readonly Func<T, bool> _predicate;

        public WhereEnumerable(IEnumerable<T> seq,
            Func<T, bool> predicate)
        {
            _seq = seq;
            _predicate = predicate;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new WhereEnumerator<T>(_seq, _predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class WhereEnumerator<T> : IEnumerator<T>
        {
            private readonly IEnumerable<T> _seq;
            private readonly Func<T, bool> _predicate;

            public T Current
            {
                get
                {
                    return _underlying.Current;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public WhereEnumerator(IEnumerable<T> seq,
                Func<T, bool> predicate)
            {
                _seq = seq;
                _predicate = predicate;
            }

            public void Dispose()
            {
            }

            private IEnumerator<T> _underlying = null;
            public bool MoveNext()
            {
                if (_underlying == null)
                    _underlying = _seq.GetEnumerator();

                var result = _underlying.MoveNext();
                while (result && !_predicate(_underlying.Current))
                    result = _underlying.MoveNext();

                return result;
            }

            public void Reset()
            {
            }
        }
    }

    public class SelectEnumerable<T, U> : IEnumerable<U>
    {
        private readonly IEnumerable<T> _seq;
        private readonly Func<T, U> _projection;

        public SelectEnumerable(IEnumerable<T> seq, Func<T, U> projection)
        {
            _seq = seq;
            _projection = projection;
        }

        public IEnumerator<U> GetEnumerator()
        {
            return new SelectEnumerator<T, U>(_seq, _projection);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class SelectEnumerator<T, U> : IEnumerator<U>
        {
            private readonly IEnumerable<T> _seq;
            private readonly Func<T, U> _projection;

            public U Current
            {
                get
                {
                    return _projection(_underlying.Current);
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public SelectEnumerator(IEnumerable<T> seq, Func<T, U> projection)
            {
                _seq = seq;
                _projection = projection;
            }

            public void Dispose()
            {
            }

            private IEnumerator<T> _underlying = null;
            public bool MoveNext()
            {
                if (_underlying == null)
                    _underlying = _seq.GetEnumerator();

                return _underlying.MoveNext();
            }

            public void Reset()
            {
            }
        }
    }

    public static class OurLinq
    {
        public static IEnumerable<T> Take<T>(this IEnumerable<T> seq,
            int count)
        {
            var taken = 0;
            foreach (var item in seq)
            {
                if (taken == count) yield break;
                yield return item;
                taken++;
            }
        }

        public static IEnumerable<U> Select<T, U>(
            this IEnumerable<T> seq,
            Func<T, U> projection
            )
        {
            foreach (var item in seq)
            {
                yield return projection(item);
            }
        }

        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> seq,
            Func<T, bool> predicate)
        {
            foreach (var item in seq)
            {
                if (!predicate(item))
                    continue;

                yield return item;
            }
        }
    }
}
