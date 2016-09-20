using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos2.MiniUzduotis
{

    public class ComplexNumberArithmeticTests
    {
        [Theory]
        [InlineData(1.0, 2.0, 3.0, 4.0, 4.0, 6.0)]
        [InlineData(1.5, 2.0, 3.0, 4.0, 4.5, 6.0)]
        [InlineData(1.0, 2.8, 3.0, 4.0, 4.0, 6.8)]
        [InlineData(1.0, 2.0, 3.3, 4.0, 4.3, 6.0)]
        [InlineData(1.0, 2.0, 3.0, 4.1, 4.0, 6.1)]
        public void ComplexNumbersAreAddedCorrectly(double real1, double imaginary1, double real2, double imaginary2, double realRes, double imaginaryRes)
        {
            var complex1 = new ComplexNumber(real1, imaginary1);
            var complex2 = new ComplexNumber(real2, imaginary2);

            var expected = new ComplexNumber(realRes, imaginaryRes);
            var actual = complex1.Add(complex2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1.0, 2.0, 3.0, 4.0, 4.0, 6.0)]
        [InlineData(1.5, 2.0, 3.0, 4.0, 4.5, 6.0)]
        [InlineData(1.0, 2.8, 3.0, 4.0, 4.0, 6.8)]
        [InlineData(1.0, 2.0, 3.3, 4.0, 4.3, 6.0)]
        [InlineData(1.0, 2.0, 3.0, 4.1, 4.0, 6.1)]
        public void ComplexNumbersAreAddedCorrectlyUsingOperator(double real1, double imaginary1, double real2, double imaginary2, double realRes, double imaginaryRes)
        {
            var complex1 = new ComplexNumber(real1, imaginary1);
            var complex2 = new ComplexNumber(real2, imaginary2);

            var expected = new ComplexNumber(realRes, imaginaryRes);
            var actual = complex1 + complex2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1.0, 2.0, 3.0, 4.0, -2.0, -2.0)]
        [InlineData(5.0, 2.0, 3.0, 4.0, 2.0, -2.0)]
        [InlineData(1.0, 5.0, 3.0, 4.0, -2.0, 1.0)]
        [InlineData(1.0, 2.0, 5.0, 4.0, -4.0, -2.0)]
        [InlineData(1.0, 2.0, 3.0, 5.0, -2.0, -3.0)]
        public void ComplexNumbersAreSubtractedCorrectly(double real1, double imaginary1, double real2, double imaginary2, double realRes, double imaginaryRes)
        {
            var complex1 = new ComplexNumber(real1, imaginary1);
            var complex2 = new ComplexNumber(real2, imaginary2);

            var expected = new ComplexNumber(realRes, imaginaryRes);
            var actual = complex1.Subtract(complex2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1.0, 2.0, 3.0, 4.0, -2.0, -2.0)]
        [InlineData(5.0, 2.0, 3.0, 4.0, 2.0, -2.0)]
        [InlineData(1.0, 5.0, 3.0, 4.0, -2.0, 1.0)]
        [InlineData(1.0, 2.0, 5.0, 4.0, -4.0, -2.0)]
        [InlineData(1.0, 2.0, 3.0, 5.0, -2.0, -3.0)]
        public void ComplexNumbersAreSubtractedCorrectlyUsingOperator(double real1, double imaginary1, double real2, double imaginary2, double realRes, double imaginaryRes)
        {
            var complex1 = new ComplexNumber(real1, imaginary1);
            var complex2 = new ComplexNumber(real2, imaginary2);

            var expected = new ComplexNumber(realRes, imaginaryRes);
            var actual = complex1 - complex2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1.0, 2.0, 3.0, 4.0, -5.0, 10.0)]
        [InlineData(2.0, 2.0, 3.0, 4.0, -2.0, 14.0)]
        [InlineData(1.0, 1.0, 3.0, 4.0, -1.0, 7.0)]
        [InlineData(1.0, 2.0, 1.0, 4.0, -7.0, 6.0)]
        [InlineData(1.0, 2.0, 3.0, 1.0, 1.0, 7.0)]
        public void ComplexNumbersAreMultipliedCorrectly(double real1, double imaginary1, double real2, double imaginary2, double realRes, double imaginaryRes)
        {
            var complex1 = new ComplexNumber(real1, imaginary1);
            var complex2 = new ComplexNumber(real2, imaginary2);

            var expected = new ComplexNumber(realRes, imaginaryRes);
            var actual = complex1.Multiply(complex2);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(1.0, 2.0, 3.0, 4.0, -5.0, 10.0)]
        [InlineData(2.0, 2.0, 3.0, 4.0, -2.0, 14.0)]
        [InlineData(1.0, 1.0, 3.0, 4.0, -1.0, 7.0)]
        [InlineData(1.0, 2.0, 1.0, 4.0, -7.0, 6.0)]
        [InlineData(1.0, 2.0, 3.0, 1.0, 1.0, 7.0)]
        public void ComplexNumbersAreMultipliedCorrectlyUsingOperator(double real1, double imaginary1, double real2, double imaginary2, double realRes, double imaginaryRes)
        {
            var complex1 = new ComplexNumber(real1, imaginary1);
            var complex2 = new ComplexNumber(real2, imaginary2);

            var expected = new ComplexNumber(realRes, imaginaryRes);
            var actual = complex1 * complex2;

            Assert.Equal(expected, actual);
        }
    }
}
