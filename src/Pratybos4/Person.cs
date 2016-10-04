using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratybos4
{
    public class Person : IComparable<Person>, IEquatable<Person>
    {
        public long SocialSecurityNumber { get;}
        public string FirstName { get;}
        public string LastName { get; }

        public Person(long socialSecurityNo, string firstName, string lastName)
        {
            SocialSecurityNumber = socialSecurityNo;
            FirstName = firstName;
            LastName = lastName;
        }

        public int CompareTo(Person other)
        {
            return FirstName.CompareTo(other.FirstName);
        }

        public override bool Equals(object obj)
        {
            var other = obj as Person;
            if (other == null) return false;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            return SocialSecurityNumber.GetHashCode();
        }

        public bool Equals(Person other)
        {
            return SocialSecurityNumber == other.SocialSecurityNumber;
        }
    }
}
