using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farkas_Szabolcs_ProiectExamen.Data;
using Farkas_Szabolcs_ProiectExamen.Models;
using System.Security.Policy;

namespace Farkas_Szabolcs_ProiectExamen.Pages.Produse
{
    public class EditModel : ProdusCategoriiPageModel
    {
        private readonly Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext _context;

        public EditModel(Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produs == null)
            {
                return NotFound();
            }
                Produs = await _context.Produs
               .Include(b => b.Producator)
               .Include(b => b.ProdusCategorii).ThenInclude(b => b.Categorie)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.ID == id);
           
            if (Produs == null)
            {
                return NotFound();
            }

            PopulateAssignedCategorieData(_context, Produs);


            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID","NumeProducator");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategorii)
        {
            if (id == null)
            {
                return NotFound();
            }
            var produsToUpdate = await _context.Produs
            .Include(i => i.Producator)
            .Include(i => i.ProdusCategorii)
            .ThenInclude(i => i.Categorie)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (produsToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Produs>(
            produsToUpdate,
            "Produs",
            i => i.Denumire, i => i.Descriere,i => i.Origine,
            i => i.Price, i => i.Pret, i => i.NrBuc, i => i.Valabilitate, i => i.ProducatorID))
            {
                UpdateProdusCategorii(_context, selectedCategorii, produsToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            
            UpdateProdusCategorii(_context, selectedCategorii, produsToUpdate);
            PopulateAssignedCategorieData(_context, produsToUpdate);
            return Page();
        }
    }
  
}

