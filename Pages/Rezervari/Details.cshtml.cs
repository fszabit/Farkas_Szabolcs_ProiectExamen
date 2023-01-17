using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Farkas_Szabolcs_ProiectExamen.Data;
using Farkas_Szabolcs_ProiectExamen.Models;

namespace Farkas_Szabolcs_ProiectExamen.Pages.Rezervari
{
    public class DetailsModel : PageModel
    {
        private readonly Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext _context;

        public DetailsModel(Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext context)
        {
            _context = context;
        }

      public Rezervare Rezervare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rezervare == null)
            {
                return NotFound();
            }

            var rezervare = await _context.Rezervare.Include(b => b.Cumparator).Include(b => b.Produs).FirstOrDefaultAsync(m => m.ID == id);
            if (rezervare == null)
            {
                return NotFound();
            }
            else 
            {
                Rezervare = rezervare;
            }
            return Page();
        }
    }
}
