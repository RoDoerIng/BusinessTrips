using BusinessTrips.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrips.WebApp.Data
{
    public class PersonSeed : Person
    {
        public int AddressId => Address.AddressId;

        public int NameId => Name.NameId;
    }
}
