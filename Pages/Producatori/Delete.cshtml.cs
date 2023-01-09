using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Farkas_Szabolcs_ProiectExamen.Data;
using Farkas_Szabolcs_ProiectExamen.Models;

namespace Farkas_Szabolcs_ProiectExamen.Pages.Producatori
{
    public class DeleteModel : PageModel
    {
        private readonly Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext _context;

        public DeleteModel(Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Producator Producator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Producator == null)
            {
                return NotFound();
            }

            var producator = await _context.Producator.FirstOrDefaultAsync(m => m.ID == id);

            if (producator == null)
            {
                return NotFound();
            }
            else 
            {
                Producator = producator;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Producator == null)
            {
                return NotFound();
            }
            var producator = await _context.Producator.FindAsync(id);

            if (producator != null)
            {
                Producator = producator;
                _context.Producator.Remove(Producator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
