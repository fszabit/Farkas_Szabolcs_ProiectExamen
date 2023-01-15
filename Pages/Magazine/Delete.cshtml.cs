﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Farkas_Szabolcs_ProiectExamen.Data;
using Farkas_Szabolcs_ProiectExamen.Models;

namespace Farkas_Szabolcs_ProiectExamen.Pages.Magazine
{
    public class DeleteModel : PageModel
    {
        private readonly Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext _context;

        public DeleteModel(Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Magazin Magazin { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Magazin == null)
            {
                return NotFound();
            }

            var magazin = await _context.Magazin.FirstOrDefaultAsync(m => m.ID == id);

            if (magazin == null)
            {
                return NotFound();
            }
            else 
            {
                Magazin = magazin;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Magazin == null)
            {
                return NotFound();
            }
            var magazin = await _context.Magazin.FindAsync(id);

            if (magazin != null)
            {
                Magazin = magazin;
                _context.Magazin.Remove(Magazin);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}