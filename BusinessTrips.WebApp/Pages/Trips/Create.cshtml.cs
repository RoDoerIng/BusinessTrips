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
        private List<Person> _persons;

        [BindProperty]
        public Trip Trip { get; set; }

        public SelectList NameOptions { get; set; }

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
            _persons = await _context.Persons.Include(p => p.Name).ToListAsync();
            NameOptions = new SelectList(_persons, nameof(Person.PersonId), "Name.LastName");
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

            var startPerson = _persons
                .First(p => p.PersonId == StartPersonId);

            var destinationPerson = _persons
                .First(p => p.PersonId == DestinationPersonId);

            Trip.StartAddress = startPerson.Address;
            Trip.DestinationAddress = destinationPerson.Address;

            TryValidateModel(Trip);

            if (!ModelState.IsValid)
                return Page();

            _context.Trips.Add(Trip);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
