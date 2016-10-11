using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratybos5.Sprendimas
{
    class Permutations
    {
        private static List<T[]> PermutationsOf<T>(T[] array, int level)
        {
            if (level == array.Length - 1)
                return new List<T[]>
                {
                    array
                };

            var permutations = new List<T[]>();
            permutations.AddRange(PermutationsOf(array, level + 1));

            for (var otherElementIndex = level + 1; otherElementIndex < array.Length; otherElementIndex++)
            {
                var copy = array.ToArray();
                Swap(copy, level, otherElementIndex);
                permutations.AddRange(PermutationsOf(copy, level + 1));
            }

            return permutations;
        }

        public static IEnumerable<IEnumerable<T>> Recursive<T>(T[] array)
        {
            return PermutationsOf(array, 0);
        }

        private static List<int[]> IntPermutations(int length)
        {
            var permutations = new List<int[]>();
            var permutation = Enumerable.Range(0, length).ToArray();

            do
            {
                permutations.Add(permutation);
                permutation = NextIntPermutation(permutation);
            }
            while (permutation != null);

            return permutations;
        }

        private static T[] MakePermutation<T>(T[] array, int[] intPermutation)
        {
            var result = new T[array.Length];

            for (var i = 0; i < array.Length; i++)
            {
                result[i] = array[intPermutation[i]];
            }

            return result;
        }

        public static IEnumerable<IEnumerable<T>> Iterative<T>(T[] array)
        {
            var intPermutations = IntPermutations(array.Length);

            var permutations = new List<IEnumerable<T>>();

            foreach (var intPermutation in intPermutations)
            {
                permutations.Add(MakePermutation(array, intPermutation));
            }

            return permutations;
        }

        private static int FindOutOfOrderIndex(int[] array)
        {
            for (var i = array.Length - 2; i >= 0; i--)
            {
                if (array[i] < array[i + 1])
                    return i;
            }

            return -1;
        }

        private static int FindLargerThan(int[] array, int value)
        {
            for (var i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] > value)
                    return i;
            }

            return -1;
        }

        private static int[] NextIntPermutation(int[] prev)
        {
            var outOfOrderIndex = FindOutOfOrderIndex(prev);
            if (outOfOrderIndex == -1) return null;

            var largerIndex = FindLargerThan(prev, prev[outOfOrderIndex]);
            var next = prev.ToArray();
            Swap(next, outOfOrderIndex, largerIndex);

            Array.Reverse(next, outOfOrderIndex + 1, next.Length - outOfOrderIndex - 1);
            return next;
        }

        private static void Swap<T>(T[] array, int idx1, int idx2)
        {
            var tmp = array[idx1];
            array[idx1] = array[idx2];
            array[idx2] = tmp;
        }
    }
}
