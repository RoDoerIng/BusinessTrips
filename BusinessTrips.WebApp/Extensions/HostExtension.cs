using BusinessTrips.Data;
using BusinessTrips.Model;
using BusinessTrips.WebApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessTrips.WebApp.Extensions
{
    public static class HostExtension
    {
        /// <summary>
        /// Executes the DB migration for a specific DbContext <typeparamref name="T"/>
        /// <para>
        ///     Code from:
        ///     https://docs.microsoft.com/en-us/archive/msdn-magazine/2019/april/data-points-ef-core-in-a-docker-containerized-app
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="webHost"></param>
        /// <returns></returns>
        public static IHost MigrateDatabase<T>(this IHost webHost) where T : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<T>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
            return webHost;
        }

        public static IHost SeedData(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<BusinessTripsContext>();

                    if (context.Persons.Any())
                        return webHost;

                    var names = NameSeeder.GetNames().ToList();
                    var addresses = AddressSeeder.GetAddresses().ToList();

                    context.Names.AddRange(names);
                    context.Addresses.AddRange(addresses);

                    var personCount = names.Count <= addresses.Count ? names.Count : addresses.Count;

                    for (int i = 0; i < personCount; i++)
                    {
                        context.Persons.Add( 
                            new Person{
                                 Address = addresses[i],
                                 Name = names[i]
                            });
                    }

                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            return webHost;
        }
    }
}
