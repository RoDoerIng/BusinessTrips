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
    public static class WebHostExtension
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
                    var db = services.GetRequiredService<T>();
                    db.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
            return webHost;
        }
    }
}
