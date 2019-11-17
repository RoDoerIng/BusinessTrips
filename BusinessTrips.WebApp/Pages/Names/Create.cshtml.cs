using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessTrips.Data;
using BusinessTrips.Model;

namespace BusinessTrips.WebApp.Pages.Names
{
    public class CreateModel : PageModel
    {
        private readonly BusinessTrips.Data.BusinessTripsContext _context;

        public CreateModel(BusinessTrips.Data.BusinessTripsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Name Name { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Name.Add(Name);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
