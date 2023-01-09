using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Farkas_Szabolcs_ProiectExamen.Data;
using Farkas_Szabolcs_ProiectExamen.Models;
using System.Security.Policy;

namespace Farkas_Szabolcs_ProiectExamen.Pages.Produse
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
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID","NumeProducator");
            return Page();
        }

        [BindProperty]
        public Produs Produs { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Produs.Add(Produs);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
