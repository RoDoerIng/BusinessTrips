﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessTrips.Data;
using BusinessTrips.Model;

namespace BusinessTrips.WebApp.Pages.Names
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessTrips.Data.BusinessTripsContext _context;

        public DetailsModel(BusinessTrips.Data.BusinessTripsContext context)
        {
            _context = context;
        }

        public Name Name { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Name = await _context.Name.FirstOrDefaultAsync(m => m.NameId == id);

            if (Name == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}