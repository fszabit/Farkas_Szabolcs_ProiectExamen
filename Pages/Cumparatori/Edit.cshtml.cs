﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farkas_Szabolcs_ProiectExamen.Data;
using Farkas_Szabolcs_ProiectExamen.Models;

namespace Farkas_Szabolcs_ProiectExamen.Pages.Cumparatori
{
    public class EditModel : PageModel
    {
        private readonly Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext _context;

        public EditModel(Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cumparator Cumparator { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cumparator == null)
            {
                return NotFound();
            }

            var cumparator =  await _context.Cumparator.FirstOrDefaultAsync(m => m.ID == id);
            if (cumparator == null)
            {
                return NotFound();
            }
            Cumparator = cumparator;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cumparator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CumparatorExists(Cumparator.ID))
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

        private bool CumparatorExists(int id)
        {
          return _context.Cumparator.Any(e => e.ID == id);
        }
    }
}
