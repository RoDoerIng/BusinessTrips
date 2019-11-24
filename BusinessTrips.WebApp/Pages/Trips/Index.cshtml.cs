using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessTrips.Data;
using BusinessTrips.Model;

namespace BusinessTrips.WebApp.Pages.Trips
{
    public class IndexModel : PageModel
    {
        private readonly BusinessTrips.Data.BusinessTripsContext _context;

        public IndexModel(BusinessTrips.Data.BusinessTripsContext context)
        {
            _context = context;
        }

        public IList<Trip> Trips { get;set; }
        public IList<Person> Persons { get;set; }

        public string StartDisplayName => "Start";
        public string DestinationDisplayName => "Destination";

        public async Task OnGetAsync()
        {
            Trips = await _context.Trips
                .Include(t=>t.StartAddress)
                .Include(t=>t.DestinationAddress)
                .ToListAsync();

            Persons = await _context.Persons
                .Include(p => p.Address)
                .Include(p => p.Name)
                .ToListAsync();
        }
    }
}
