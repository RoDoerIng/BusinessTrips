using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BusinessTrips.Model;
using BusinessTrips.WebApp.Data;

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

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>().HasData(AddressSeeder.GetAddresses());
            modelBuilder.Entity<Name>().HasData(NameSeeder.GetNames());

        }
    }
}
