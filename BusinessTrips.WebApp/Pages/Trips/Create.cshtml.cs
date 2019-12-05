using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessTrips.Data;
using BusinessTrips.Model;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrips.WebApp.Pages.Trips
{
    public class CreateModel : PageModel
    {
        private readonly BusinessTrips.Data.BusinessTripsContext _context;

        [BindProperty]
        public Trip Trip { get; set; }

        // https://www.learnrazorpages.com/razor-pages/tag-helpers/select-tag-helper
        public List<SelectListItem> NameOptions { get; set; }

        [BindProperty]
        public int StartPersonId { get; set; }


        [BindProperty]
        public int DestinationPersonId { get; set; }

        public CreateModel(BusinessTrips.Data.BusinessTripsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            var persons = await GetPersonsWithNamesAndAddresses();
            
            NameOptions = persons
                .Select(p => new SelectListItem(
                    $"{p.Name.LastName} {p.Name.FirstName.FirstOrDefault()}.",
                    $"{p.PersonId}"))
                .ToList();

            // TODO: Set todays date via HTML?
            Trip = new Trip();
            Trip.Date = DateTime.Today;

            return Page();
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Clear();

            var persons = await GetPersonsWithNamesAndAddresses();

            Trip.StartAddress = GetAddress(persons, StartPersonId);
            Trip.DestinationAddress = GetAddress(persons, DestinationPersonId);

            TryValidateModel(Trip);

            if (!ModelState.IsValid)
                return Page();

            _context.Trips.Add(Trip);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private async Task<IList<Person>> GetPersonsWithNamesAndAddresses()
        {
            return await _context.Persons
                .Include(p => p.Name)
                .Include(p=>p.Address)
                .ToListAsync();
        }

        private Address GetAddress(IEnumerable<Person> persons, int personId)
        {
            return persons?.FirstOrDefault(p => p.PersonId == personId)?.Address;
        }
    }
}
