using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratybos6
{
    public static class MaybeExtensions
    {
        public static Maybe<U> Bind<T, U>(this Maybe<T> value, 
            Func<T, Maybe<U>> projection)
        {
            if (!value.HasValue)
                return new Maybe<U>();

            return projection(value.Value);
        }

        public static Maybe<U> Select<T, U>(this Maybe<T> maybe,
            Func<T, U> projection
            )
        {
            if (!maybe.HasValue)
                return new Maybe<U>();

            return new Maybe<U>(projection(maybe.Value));
        }

        public static Maybe<TResult> SelectMany<TSource, TCollection, TResult>(
            this Maybe<TSource> maybe, 
            Func<TSource, Maybe<TCollection>> collectionSelector, 
            Func<TSource, TCollection, TResult> resultSelector)
        {
            if (maybe.HasValue)
            {
                var resultMaybe = collectionSelector(maybe.Value);
                if (!resultMaybe.HasValue) return new Maybe<TResult>();
                return new Maybe<TResult>(resultSelector(maybe.Value, resultMaybe.Value));

            }
            else
            {
                return new Maybe<TResult>();
            }
        }
    }
}
