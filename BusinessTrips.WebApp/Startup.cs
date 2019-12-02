using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using BusinessTrips.Data;
using System.Globalization;

namespace BusinessTrips.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ref: https://stackoverflow.com/questions/40442444/set-cultureinfo-in-asp-net-core-to-have-a-as-currencydecimalseparator-instead
            var defaultCultureInfo = new CultureInfo("de-DE");
            defaultCultureInfo.NumberFormat.NumberDecimalSeparator = ".";
            defaultCultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";

            // ref: https://dotnetcoretutorials.com/2017/06/22/request-culture-asp-net-core/
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(defaultCultureInfo);
                //By default the below will be set to whatever the server culture is. 
                options.SupportedCultures = new List<CultureInfo> { defaultCultureInfo };
            });

            services.AddRazorPages();

            services.AddDbContext<BusinessTripsContext>(options =>
                    options
                    //.UseSqlServer(@"Server=192.168.188.104;Database=master;User Id=sa;Password=P@ssw0rd;")
                    //.UseInMemoryDatabase("BusinessTrips")
                    .UseSqlite(@"Data Source = businesstrips.sqlite")
                    );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
