using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Farkas_Szabolcs_ProiectExamen.Data;
using Farkas_Szabolcs_ProiectExamen.Models;
using System.Net;

namespace Farkas_Szabolcs_ProiectExamen.Pages.Produse
{
    public class IndexModel : PageModel
    {
        private readonly Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext _context;

        public IndexModel(Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext context)
        {
            _context = context;
        }

        public IList<Produs> Produs { get;set; } = default!;
        public ProdusData ProdusD { get; set; }
        public int ProdusID { get; set; }
       

        public string DenumireSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync( string sortOrder, string searchString)
        {

            ProdusD = new ProdusData();

            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "denumire_desc" : "";
           
            CurrentFilter = searchString;

                ProdusD.Produse = await _context.Produs
                    .Include(b=>b.Producator)
                    .Include(b => b.Magazin)
                    .Include(b => b.ProdusCategorii)
                    .ThenInclude(b => b.Categorie)
                    .AsNoTracking()
                    .OrderBy(b => b.Denumire)
                    .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ProdusD.Produse = ProdusD.Produse.Where(s => s.Denumire.Contains(searchString)||s.Producator.NumeProducator.Contains(searchString));
            }
           

            switch (sortOrder)
            {
                case "denumire_desc":
                    ProdusD.Produse = ProdusD.Produse.OrderByDescending(s =>s.Denumire);
                    break;
               


            }

        }
    }
}
