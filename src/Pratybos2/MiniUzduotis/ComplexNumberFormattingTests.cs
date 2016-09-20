using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos2.MiniUzduotis
{
    public class ComplexNumberFormattingTests
    {
        [Theory]
        [InlineData(1.0, 2.0, "1 + 2i")]
        [InlineData(2.0, 3.0, "2 + 3i")]
        [InlineData(1.5, 2.38, "1.5 + 2.38i")]
        [InlineData(1.54354, 2.384654, "1.54354 + 2.384654i")]
        [InlineData(2.0, -3.0, "2 - 3i")]
        [InlineData(1.0, 1.0, "1 + i")]
        [InlineData(1.0, -1.0, "1 - i")]
        [InlineData(1.0, 0.0, "1")]
        [InlineData(0.0, 2.0, "2i")]
        [InlineData(0.0, -2.0, "-2i")]
        [InlineData(0.0, 0.0, "0")]
        [InlineData(0.0, 1.0, "i")]
        [InlineData(0.0, -1.0, "-i")]
        public void ComplexNumbersAreFormattedCorrectly(double real, double imaginary, string expected)
        {
            var complex = new ComplexNumber(real, imaginary);
            Assert.Equal(expected, complex.ToString());
        }
    }
}
