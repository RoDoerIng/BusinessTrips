using BusinessTrips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrips.WebApp.Data
{
    public class NameSeeder
    {
        public static IEnumerable<Name> GetNames()
        {
            return new List<Name>
            {
                new Name
                {
                    NameId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                },
                new Name
                {
                    NameId = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                },
                new Name
                {
                    NameId = 3,
                    FirstName = "FooBert",
                    LastName = "BazMan",
                }
            };
        }
    }
}
