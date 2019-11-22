using BusinessTrips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrips.WebApp.Data
{
    public class AddressSeeder
    {
        public static IEnumerable<Address> GetAddresses()
        {
            return new List<Address>
            {
                new Address
                {
                    AddressId = 1,
                    Street = "FooStreet",
                    StreetNumber = "42",
                    PostCode = "12345",
                    City = "FooCity"
                },
                new Address
                {
                    AddressId = 2,
                    Street = "BarAvenue",
                    StreetNumber = "0",
                    PostCode = "99999",
                    City = "BarTown"
                },
                new Address
                {
                    AddressId = 3,
                    Street = "BazWay",
                    StreetNumber = "99",
                    PostCode = "00000",
                    City = "BazVillage"
                },
            };
        }
    }
}
