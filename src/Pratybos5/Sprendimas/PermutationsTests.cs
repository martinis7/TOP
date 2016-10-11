using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos5.Sprendimas
{
    public abstract class PermutationsTests
    {
        [Theory]
        [InlineData("a")]
        [InlineData("b")]
        public void AllCombinationsOfASingleElementIsTheSameElement(string element)
        {
            var expected = new[]
            {
                new [] { element }
            };
            var actual = PermutationsOf(new[] { element });
            Assert.Equal(expected, actual, CombinationsComparer<string>());
        }

        [Theory]
        [InlineData(new[] { 1, 2 })]
        [InlineData(new[] { 7, 12 })]
        [InlineData(new[] { 7, 7 })]
        public void AllCombinationsOfTwoElementsSequenceIsSameSequenceAndReversedSequence(int[] sequence)
        {
            var expected = new[]
            {
                sequence,
                sequence.Reverse().ToArray()
            };

            var actual = PermutationsOf(sequence);
            Assert.Equal(expected, actual, CombinationsComparer<int>());
        }

        [Fact]
        public void AllCombinationsOfThreeElementSequenceAreReturned()
        {
            var sequence = new[] { "a", "b", "c" };

            var expected = new[]
            {
                new[] { "a", "b", "c" },
                new[] { "a", "c", "b" },
                new[] { "b", "a", "c" },
                new[] { "b", "c", "a" },
                new[] { "c", "b", "a" },
                new[] { "c", "a", "b" },
            };

            var actual = PermutationsOf(sequence);
            Assert.Equal(expected, actual, CombinationsComparer<string>());
        }

        [Fact]
        public void AllCombinationsOfFourElementSequenceAreReturned()
        {
            var sequence = new[] { 1, 7, 4, 12 };

            var expected = new[]
            {
                new[] { 1, 7, 4, 12 },
                new[] { 1, 7, 12, 4 },
                new[] { 1, 4, 7, 12 },
                new[] { 1, 4, 12, 7 },
                new[] { 1, 12, 4, 7 },
                new[] { 1, 12, 7, 4 },

                new[] { 7, 1, 4, 12 },
                new[] { 7, 1, 12, 4 },
                new[] { 7, 4, 1, 12 },
                new[] { 7, 4, 12, 1 },
                new[] { 7, 12, 1, 4 },
                new[] { 7, 12, 4, 1 },

                new[] { 4, 1, 7, 12 },
                new[] { 4, 1, 12, 7 },
                new[] { 4, 7, 1, 12 },
                new[] { 4, 7, 12, 1 },
                new[] { 4, 12, 1, 7 },
                new[] { 4, 12, 7, 1 },

                new[] { 12, 1, 7, 4 },
                new[] { 12, 1, 4, 7 },
                new[] { 12, 7, 1, 4 },
                new[] { 12, 7, 4, 1 },
                new[] { 12, 4, 1, 7 },
                new[] { 12, 4, 7, 1 }
            };

            var actual = PermutationsOf(sequence);
            Assert.Equal(expected, actual, CombinationsComparer<int>());
        }

        protected abstract IEnumerable<IEnumerable<T>> PermutationsOf<T>(T[] sequence);

        private static IEqualityComparer<IEnumerable<IEnumerable<T>>> CombinationsComparer<T>()
        {
            return new SetEqualityComparer<IEnumerable<T>>(new SequenceEqualityComparer<T>());
        }


        class SequenceEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
        {
            public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
            {
                return x.SequenceEqual(y);
            }

            public int GetHashCode(IEnumerable<T> obj)
            {
                return 1;
            }
        }

        class SetEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
        {
            private readonly IEqualityComparer<T> _elementComparer;

            public SetEqualityComparer(IEqualityComparer<T> elementComparer)
            {
                _elementComparer = elementComparer;
            }

            public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
            {
                var xArray = x.ToArray();
                var yArray = y.ToArray();
                if (xArray.Length != yArray.Length)
                    return false;

                foreach (var element in xArray)
                {
                    if (!yArray.Contains(element, _elementComparer))
                        return false;
                }

                return true;
            }

            public int GetHashCode(IEnumerable<T> obj)
            {
                return 1;
            }
        }
    }

    public class RecursivePermutationsTests : PermutationsTests
    {
        protected override IEnumerable<IEnumerable<T>> PermutationsOf<T>(T[] sequence)
        {
            return Permutations.Recursive(sequence);
        }
    }

    public class IterativePermutationsTests : PermutationsTests
    {
        protected override IEnumerable<IEnumerable<T>> PermutationsOf<T>(T[] sequence)
        {
            return Permutations.Iterative(sequence);
        }
    }
}
