using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessTrips.Model;

namespace BusinessTrips.Data
{
    public class BusinessTripsContext : DbContext
    {
        public BusinessTripsContext (DbContextOptions<BusinessTripsContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessTrips.Model.Person> Persons { get; set; }

        public DbSet<BusinessTrips.Model.Address> Addresses { get; set; }

        public DbSet<BusinessTrips.Model.Name> Names { get; set; }
    }
}
