using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Farkas_Szabolcs_ProiectExamen.Data;
using Farkas_Szabolcs_ProiectExamen.Models;

namespace Farkas_Szabolcs_ProiectExamen.Pages.Produse
{
    public class DeleteModel : PageModel
    {
        private readonly Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext _context;

        public DeleteModel(Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Produs Produs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }

            var produs = await _context.Produs.Include(b => b.Producator).FirstOrDefaultAsync(m => m.ID == id);

            if (produs == null)
            {
                return NotFound();
            }
            else 
            {
                Produs = produs;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }
            var produs = await _context.Produs.FindAsync(id);

            if (produs != null)
            {
                Produs = produs;
                _context.Produs.Remove(Produs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
