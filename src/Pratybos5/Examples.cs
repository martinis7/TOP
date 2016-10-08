using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos5
{
    public class Examples
    {
        [Fact]
        public void CorrectIpIsMatched()
        {
            var ip = "192.168.1.1";
            Assert.True(IpAddress.IsIpAddress(ip));
        }

        [Fact]
        public void IncorrectIpIsNotMatched()
        {
            var ip = "df92.168.1.1";
            Assert.False(IpAddress.IsIpAddress(ip));
        }

        [Fact]
        public void IpIsParsed()
        {
            var ip = "192.168.1.1";
            var expected = new IpAddress(192, 168, 1, 1);
            var actual = IpAddress.Parse(ip);

            Assert.Equal(expected, actual);
        }
    }
}
