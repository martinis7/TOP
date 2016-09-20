using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos2.MiniUzduotis
{
    public class ComplexNumberEqualityTests
    {
        [Theory]
        [InlineData(0.4)]
        [InlineData(-4.6)]
        public void ComplexNumbersWithNoImaginaryPartAndSameRealPartAreEqual(double realPart)
        {
            var x = new ComplexNumber(realPart);
            var y = new ComplexNumber(realPart);

            Assert.Equal(x, y);
        }

        [Theory]
        [InlineData(0.4, 0.43)]
        [InlineData(-4.6, 0.4)]
        public void ComplexNumbersWithNoImaginaryPartAndDifferentRealPartsAreNotEqual(double realPart1, double realPart2)
        {
            var x = new ComplexNumber(realPart1);
            var y = new ComplexNumber(realPart2);

            Assert.NotEqual(x, y);
        }

        [Theory]
        [InlineData(0.4, -3.7)]
        [InlineData(-4.6, 2.2)]
        public void ComplexNumbersSameImaginaryPartAndSameRealPartAreEqual(double realPart, double imaginaryPart)
        {
            var x = new ComplexNumber(realPart, imaginaryPart);
            var y = new ComplexNumber(realPart, imaginaryPart);

            Assert.Equal(x, y);
        }

        [Theory]
        [InlineData(0.4, 0.43, 0.4)]
        [InlineData(-4.6, 0.4, 0.8)]
        public void ComplexNumbersWithSameImaginaryPartAndDifferentRealPartsAreNotEqual(double realPart1, double realPart2, double imaginaryPart)
        {
            var x = new ComplexNumber(realPart1, imaginaryPart);
            var y = new ComplexNumber(realPart2, imaginaryPart);

            Assert.NotEqual(x, y);
        }

        [Theory]
        [InlineData(0.4, 0.43, 0.4)]
        [InlineData(-4.6, 0.4, 0.8)]
        public void ComplexNumbersWithDifferentImaginaryPartAndSameRealPartsAreNotEqual(double realPart, double imaginaryPart1, double imaginaryPart2)
        {
            var x = new ComplexNumber(realPart, imaginaryPart1);
            var y = new ComplexNumber(realPart, imaginaryPart2);

            Assert.NotEqual(x, y);
        }

        [Fact]
        public void ComplexNumbersWithZeroImaginaryPartAreEqualToOnesWithoutOneSpecified()
        {
            var x = new ComplexNumber(1, 0);
            var y = new ComplexNumber(1);

            Assert.Equal(x, y);
        }

        [Theory]
        [InlineData(1.0)]
        [InlineData(-5.6)]
        public void ComplexNumbersWithNonZeroImaginaryPartAreNotEqualToOnesWithoutOneSpecified(double imaginaryPart)
        {
            var x = new ComplexNumber(1, imaginaryPart);
            var y = new ComplexNumber(1);

            Assert.NotEqual(x, y);
        }
    }
}
