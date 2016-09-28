using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos3
{

    class Examples
    {
        public static void TestBed()
        {
            var ip = new IpAddress(new byte[] { 1, 2, 3, 4 });
            Assert.Equal(1, ip[0]);
            Assert.Equal(2, ip[1]);

            var intMaybe = new Maybe<int>(3);
            var boolMaybe = new Maybe<bool>(false);

            var stringMaybe2 = Maybe.Of<string>(null);
        }

        public static void SwitchTest()
        {
            var value = "";
            switch (value)
            {
                case "":
                    Console.WriteLine("dsdgf");
                    return;
                case "d":
                case "f":
                    Console.WriteLine("abc");
                    goto case "";
                case "e":
                    while (true)
                    {

                    }
                default:
                    throw new Exception("whatever");
            }
        }

    }
}
