using BusinessTrips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrips.WebApp.Data
{
    public class PersonSeeder
    {
        public static IEnumerable<PersonSeed> GetPersons()
        {
            return new List<PersonSeed>
            {
                new PersonSeed
                {
                    PersonId = 1,
                    Address = AddressSeeder.GetAddresses().ElementAt(0),
                    Name = NameSeeder.GetNames().ElementAt(0),
                },
                new PersonSeed
                {
                    PersonId = 2,
                    Address = AddressSeeder.GetAddresses().ElementAt(1),
                    Name = NameSeeder.GetNames().ElementAt(1),
                },
                new PersonSeed
                {
                    PersonId = 3,
                    Address = AddressSeeder.GetAddresses().ElementAt(2),
                    Name = NameSeeder.GetNames().ElementAt(2),
                }

            };
        }
    }
}
