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
    public class CreateModel : ProdusCategoriiPageModel
    {
        private readonly Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext _context;

        public CreateModel(Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Produs Produs { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
           
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID", "NumeProducator");


            var produs = new Produs();
            produs.ProdusCategorii = new List<ProdusCategorie>();
            PopulateAssignedCategorieData(_context, produs);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategorii)
        {
            
            var newProdus = new Produs();
            if (selectedCategorii != null)
            {
                newProdus.ProdusCategorii = new List<ProdusCategorie>();
                foreach (var cat in selectedCategorii)
                {
                    var catToAdd = new ProdusCategorie
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newProdus.ProdusCategorii.Add(catToAdd);
                }
            }
            Produs.ProdusCategorii = newProdus.ProdusCategorii;
            _context.Produs.Add(Produs);
            await _context.SaveChangesAsync();            return RedirectToPage("./Index");
            PopulateAssignedCategorieData(_context, newProdus);
            return Page();
        }
    }

}

