using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pratybos4
{
    public class PersonTests
    {
        [Fact(Skip ="")]
        public void ArrayIsSorted()
        {
            var people = new[]
            {
                new Person(123, "Joe", "Doe"),
                new Person(456, "Billy", "Williams")
            };

            var peopleCopy = people.ToArray();

            Array.Sort(peopleCopy);

            var expected = new[]
            {
                people[1],
                people[0]
            };

            Assert.Equal(expected, peopleCopy);
        }

        [Fact(Skip ="")]
        public void SetIsSorted()
        {
            var people = new[]
            {
                new Person(123, "Joe", "Doe"),
                new Person(456, "Billy", "Williams"),
                new Person(456, "Billy", "Johnes")
            };

            var set = new SortedSet<Person>(people);

            var expected = new[]
            {
                people[1],
                people[0]
            };

            Assert.Equal(expected, set.ToArray());
        }

        [Fact]
        public void ArrayIsSortedByOtherProperty()
        {
            var people = new[]
            {
                new Person(123, "Joe", "Doe"),
                new Person(456, "Billy", "Williams")
            };

            var peopleCopy = people.ToArray();

            Array.Sort(peopleCopy, new LastNameComparer());

            var expected = new[]
            {
                people[0],
                people[1]
            };

            Assert.Equal(expected, peopleCopy);
        }

        public class LastNameComparer : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.LastName.CompareTo(y.LastName);
            }
        }
    }
}
