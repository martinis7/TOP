using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pratybos4
{
    class Person
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
    }
}
