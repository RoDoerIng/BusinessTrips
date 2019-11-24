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
        public BusinessTripsContext(DbContextOptions<BusinessTripsContext> options)
            : base(options)
        {
        }

        public DbSet<BusinessTrips.Model.Person> Persons { get; set; }

        public DbSet<BusinessTrips.Model.Address> Addresses { get; set; }

        public DbSet<BusinessTrips.Model.Name> Names { get; set; }

        public DbSet<BusinessTrips.Model.Trip> Trips { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Address>().HasData(AddressSeeder.GetAddresses());
            modelBuilder.Entity<Name>().HasData(NameSeeder.GetNames());
            modelBuilder.Entity<Person>().HasData(
                new { PersonId = 1, AddressId = 1, NameId = 1 },
                new { PersonId = 2, AddressId = 2, NameId = 2 },
                new { PersonId = 3, AddressId = 3, NameId = 3 });

            modelBuilder.Entity<Trip>().HasData(
                new { TripId = 1, Distance = 2.3m, Date = DateTime.Now.AddYears(-30), StartAddressAddressId = 1, DestinationAddressAddressId = 2 },
                new { TripId = 2, Distance = 4.0m, Date = DateTime.Now.AddYears(-10), StartAddressAddressId = 2, DestinationAddressAddressId = 3 },
                new { TripId = 3, Distance = 1.9m, Date = DateTime.Now.AddDays(-455), StartAddressAddressId = 3, DestinationAddressAddressId = 1 });
        }

    }
}
