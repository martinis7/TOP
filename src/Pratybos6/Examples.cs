﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratybos6
{
    public class Examples
    {
        public static void ForEachExample()
        {
            var array = new List<int>();

            foreach (var item in array)
                Console.WriteLine(item);

            using (var enumerator = array.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
            }
        }

        public static void LinqExamples()
        {
            var list = new List<int>();

            var squares = from item in list
                          where item % 2 == 0
                          select item * item;

            squares = squares.Select(item => item * item);

            squares = new SelectEnumerable<int, int>(
                new WhereEnumerable<int>(
                    list,
                    item => item % 2 == 0),
                item => item * item);
        }

        public void MaybeExamples()
        {
            var result = from x in new Maybe<int>(1)
                         from y in DivideBy(x, 0)
                         select y;
        }

        public Maybe<int> DivideBy(int x, int y)
        {
            if (y == 0)
                return new Maybe<int>();
            return new Maybe<int>(x / y);
        }
    }
}
