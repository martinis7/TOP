using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratybos1
{
    class Program
    {
        static void Main(string[] args)
        {
            var interval = new Interval(new DateTime(2016, 01, 02), new DateTime(2016, 01, 05));

            var line = Console.ReadLine();
            var date = DateTime.Parse(line);
            var result = interval.Contains(date);

            Console.WriteLine(result);
        }
    }
}
