using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos6
{
    public class FibonacciTests
    {
        [Fact]
        public void FibonacciReturnsCorrectSequence()
        {
            var expected = new[] { 1, 2, 3, 5, 8, 13 };
            var actual = Sequences.Fibonacci().Take(6);

            Assert.Equal(expected, actual);
        }
    }
}
