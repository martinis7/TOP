using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos3
{
    public class IpAddressTests
    {
        [Theory]
        [InlineData(1U, 1U, true)]
        [InlineData(1U, 2U, false)]
        [InlineData(2U, 2U, true)]
        public void EqualsWorksCorrectly(uint value1, uint value2, bool shouldEqual)
        {
            var ip1 = new IpAddress(value1);
            var ip2 = new IpAddress(value2);

            Assert.Equal(shouldEqual, ip1.Equals(ip2));
        }

        [Theory]
        [InlineData(0xC0A80A03U, new byte[] { 192, 168, 10, 3 })]
        [InlineData(0x01020304U, new byte[] { 1, 2, 3, 4 })]
        public void IpAddressConstructorsAreEquivalent(uint value, byte[] octets)
        {
            var ip1 = new IpAddress(value);
            var ip2 = new IpAddress(octets);

            Assert.Equal(ip1, ip2);
        }

        [Theory]
        [InlineData(new byte[] { 192, 168, 10, 3 })]
        [InlineData(new byte[] { 1, 2, 3, 4 })]
        public void OctetsAreCorrect(byte[] octets)
        {
            var ip = new IpAddress(octets);

            Assert.Equal(octets, ip.Octets);
        }

        [Theory]
        [InlineData(new byte[] { 192, 168, 10, 3 }, 2, (byte)10)]
        [InlineData(new byte[] { 192, 168, 10, 3 }, 1, (byte)168)]
        [InlineData(new byte[] { 1, 2, 3, 4 }, 1, (byte)2)]
        public void IndexerWorksCorrectly(byte[] octets, int index, byte expected)
        {
            var ip = new IpAddress(octets);

            Assert.Equal(expected, ip[index]);
        }

        [Theory]
        [InlineData(new byte[] { 192, 168, 10, 3 }, new byte[] { 255, 0, 255, 0 }, new byte[] { 192, 0, 10, 0 })]
        [InlineData(new byte[] { 192, 168, 250, 176 }, new byte[] { 172, 231, 8, 20 }, new byte[] { 128, 160, 8, 16 })]
        public void BitwiseAndWorksCorrectly(byte[] octets1, byte[] octets2, byte[] expectedOctets)
        {
            var ip1 = new IpAddress(octets1);
            var ip2 = new IpAddress(octets2);

            var expected = new IpAddress(expectedOctets);
            var actual = ip1 & ip2;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new byte[] { 192, 168, 10, 3 }, new byte[] { 192, 168, 10, 0 }, new byte[] { 255, 255, 255, 0 }, true)]
        [InlineData(new byte[] { 192, 168, 10, 3 }, new byte[] { 192, 168, 9, 0 }, new byte[] { 255, 255, 255, 0 }, false)]
        [InlineData(new byte[] { 192, 168, 9, 3 }, new byte[] { 192, 168, 9, 0 }, new byte[] { 255, 255, 255, 0 }, true)]
        [InlineData(new byte[] { 192, 168, 10, 3 }, new byte[] { 192, 168, 0, 0 }, new byte[] { 255, 255, 255, 0 }, false)]
        [InlineData(new byte[] { 192, 168, 10, 3 }, new byte[] { 192, 168, 0, 0 }, new byte[] { 255, 255, 0, 0 }, true)]
        [InlineData(new byte[] { 192, 168, 10, 3 }, new byte[] { 192, 167, 0, 0 }, new byte[] { 255, 255, 0, 0 }, false)]
        public void IsInSubnetWorksCorrectly(byte[] octets, byte[] subnetOctets, byte[] maskOctets, bool expected)
        {
            var ip = new IpAddress(octets);
            var subnet = new IpAddress(subnetOctets);
            var mask = new IpAddress(maskOctets);


            Assert.Equal(expected, ip.IsInSubnet(subnet, mask));
        }
    }
}
