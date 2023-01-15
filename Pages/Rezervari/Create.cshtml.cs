using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Farkas_Szabolcs_ProiectExamen.Data;
using Farkas_Szabolcs_ProiectExamen.Models;

namespace Farkas_Szabolcs_ProiectExamen.Pages.Rezervari
{
    public class CreateModel : PageModel
    {
        private readonly Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext _context;

        public CreateModel(Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CumparatorID"] = new SelectList(_context.Cumparator, "ID", "FullName");
        ViewData["ProdusID"] = new SelectList(_context.Produs, "ID", "Denumire");
            return Page();
        }

        [BindProperty]
        public Rezervare Rezervare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Rezervare.Add(Rezervare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
