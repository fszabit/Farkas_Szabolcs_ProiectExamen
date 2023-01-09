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
    public class IndexModel : PageModel
    {
        private readonly Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext _context;

        public IndexModel(Farkas_Szabolcs_ProiectExamen.Data.Farkas_Szabolcs_ProiectExamenContext context)
        {
            _context = context;
        }

        public IList<Producator> Producator { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Producator != null)
            {
                Producator = await _context.Producator.ToListAsync();
            }
        }
    }
}
