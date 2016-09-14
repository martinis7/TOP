using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos2
{
    public interface IPoint
    {
        int X { get; set; }
        int Y { get; set; }
    }

    public struct PointStruct : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointStruct(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class PointClass : IPoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointClass(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static double operator -(PointClass l, PointClass r)
        {
            var diffX = Math.Abs(l.X - r.X);
            var diffY = Math.Abs(l.Y - r.Y);

            return Math.Sqrt(diffX * diffX + diffY * diffY);
        }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }

        public static explicit operator string(PointClass p)
        {
            return p.ToString();
        }
    }

    public class PointOperations
    {
        public static PointStruct SetXOnStruct(PointStruct p, int value)
        {
            p.X = value;
            return p;
        }

        public static PointClass SetXOnClass(PointClass p, int value)
        {
            p.X = value;
            return p;
        }

        public static IPoint SetXOnInterface(IPoint p, int value)
        {
            p.X = value;
            return p;
        }
    }
}
