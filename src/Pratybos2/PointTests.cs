using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos2
{
    public class PointTests
    {
        [Fact]
        public void XCanBeAssignedOnClass()
        {
            var point = new PointClass(1, 2);
            point.X = 3;

            Assert.Equal(3, point.X);
        }

        [Fact]
        public void XCanBeAssignedOnClassThroughMethod()
        {
            var point = new PointClass(1, 2);
            PointOperations.SetXOnClass(point, 3);

            Assert.Equal(3, point.X);
        }

        [Fact]
        public void XCanBeAssignedOnStructThroughMethod()
        {
            var point = new PointStruct(1, 2);
            PointOperations.SetXOnStruct(point, 3);

            Assert.Equal(1, point.X);
        }

        [Fact]
        public void XCanBeAssignedOnStructThroughMethodThatReturns()
        {
            var point = new PointStruct(1, 2);
            point = PointOperations.SetXOnStruct(point, 3);

            Assert.Equal(3, point.X);
        }

        [Fact]
        public void XCanBeAssignedOnStructThroughInterface()
        {
            IPoint point = new PointStruct(1, 2);
            PointOperations.SetXOnInterface(point, 3);

            Assert.Equal(3, point.X);
        }

        [Fact]
        public void DistanceCanBeCalculated()
        {
            var p1 = new PointClass(1, 0);
            var p2 = new PointClass(4, 0);

            var distance = p2 - p1;
            Assert.Equal(3.0, distance);
        }

        [Fact]
        public void ToStringWorksCorrectly()
        {
            var p = new PointClass(1, 4);
            var message = "p: " + p;
            Assert.Equal("p: 1:4", message);
        }

        [Fact]
        public void ConversionWorksCorrectly()
        {
            string p = (string)new PointClass(1, 4);
            var message = "p: " + p;
            Assert.Equal("p: 1:4", message);
        }
    }
}
