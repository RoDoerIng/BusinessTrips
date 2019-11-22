using BusinessTrips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrips.WebApp.Data
{
    public class PersonSeeder
    {
        public static IEnumerable<Person> GetPersons()
        {
            return new List<Person>
            {
                new Person
                {
                    PersonId = 1,
                    Address = AddressSeeder.GetAddresses().ElementAt(0),
                    Name = NameSeeder.GetNames().ElementAt(0),
                },
                new Person
                {
                    PersonId = 2,
                    Address = AddressSeeder.GetAddresses().ElementAt(1),
                    Name = NameSeeder.GetNames().ElementAt(1),
                },
                new Person
                {
                    PersonId = 3,
                    Address = AddressSeeder.GetAddresses().ElementAt(2),
                    Name = NameSeeder.GetNames().ElementAt(2),
                }

            };
        }
    }
}
