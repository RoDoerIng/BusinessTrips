using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessTrips.Data;
using BusinessTrips.Model;

namespace BusinessTrips.WebApp.Pages.Trips
{
    public class EditModel : PageModel
    {
        private readonly BusinessTrips.Data.BusinessTripsContext _context;

        private List<Person> _persons;

        public SelectList NameOptions { get; private set; }

        [BindProperty]
        public int StartPersonId { get; set; }

        [BindProperty]
        public int DestinationPersonId { get; set; }

        public EditModel(BusinessTrips.Data.BusinessTripsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trip Trip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _persons = await _context.Persons.Include(p => p.Name).ToListAsync();
            NameOptions = new SelectList(_persons, nameof(Person.PersonId), "Name.LastName");

            Trip = await _context.Trips
                .Include(t=>t.StartAddress)
                .Include(t=>t.DestinationAddress)
                .FirstOrDefaultAsync(m => m.TripId == id);

            StartPersonId = _persons.FirstOrDefault(p => p.Address == Trip.StartAddress)?.PersonId ?? -1;
            DestinationPersonId = _persons.FirstOrDefault(p => p.Address == Trip.DestinationAddress)?.PersonId ?? -1;

            if (Trip == null)
            {
                return NotFound();
            }
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

            _context.Attach(Trip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(Trip.TripId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TripExists(int id)
        {
            return _context.Trips.Any(e => e.TripId == id);
        }
    }
}
