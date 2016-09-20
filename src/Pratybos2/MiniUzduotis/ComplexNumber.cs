using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos2.MiniUzduotis
{
    public struct ComplexNumber
    {
        private double _imaginaryPart;
        private double _realPart;

        public ComplexNumber(double realPart) : this(realPart, 0)
        {
        }

        public ComplexNumber(double realPart, double imaginaryPart)
        {
            _realPart = realPart;
            _imaginaryPart = imaginaryPart;
        }

        public ComplexNumber Add(ComplexNumber other)
        {
            return new ComplexNumber(_realPart + other._realPart, _imaginaryPart + other._imaginaryPart);
        }

        public ComplexNumber Subtract(ComplexNumber other)
        {
            return new ComplexNumber(_realPart - other._realPart, _imaginaryPart - other._imaginaryPart);
        }

        public ComplexNumber Multiply(ComplexNumber other)
        {
            var newReal = _realPart * other._realPart - _imaginaryPart * other._imaginaryPart;
            var newImaginary = _realPart * other._imaginaryPart + _imaginaryPart * other._realPart;
            return new ComplexNumber(newReal, newImaginary);
        }

        public override string ToString()
        {
            if (_imaginaryPart == 0.0)
                return _realPart.ToString();

            if (_realPart == 0.0 && _imaginaryPart == 1.0)
                return "i";

            if (_realPart == 0.0 && _imaginaryPart == -1.0)
                return "-i";

            if (_realPart == 0.0)
                return $"{_imaginaryPart}i";

            if (Math.Abs(_imaginaryPart) == 1.0)
                return $"{_realPart} {_imaginaryPart:+;-} i";

            return $"{_realPart} {_imaginaryPart:+;-} {Math.Abs(_imaginaryPart)}i";
        }

        public static ComplexNumber operator+(ComplexNumber l, ComplexNumber r)
        {
            return l.Add(r);
        }

        public static ComplexNumber operator -(ComplexNumber l, ComplexNumber r)
        {
            return l.Subtract(r);
        }

        public static ComplexNumber operator *(ComplexNumber l, ComplexNumber r)
        {
            return l.Multiply(r);
        }
    }
}
