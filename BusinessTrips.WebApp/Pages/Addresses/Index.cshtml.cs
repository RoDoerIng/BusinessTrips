using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessTrips.Data;
using BusinessTrips.Model;

namespace BusinessTrips.WebApp.Pages.Addresses
{
    public class IndexModel : PageModel
    {
        private readonly BusinessTrips.Data.BusinessTripsContext _context;

        public IndexModel(BusinessTrips.Data.BusinessTripsContext context)
        {
            _context = context;
        }

        public IList<Address> Addresses { get;set; }

        public async Task OnGetAsync()
        {
            Addresses = await _context.Addresses.ToListAsync();
        }
    }
}
