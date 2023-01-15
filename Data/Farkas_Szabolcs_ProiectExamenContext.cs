using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farkas_Szabolcs_ProiectExamen.Models;

namespace Farkas_Szabolcs_ProiectExamen.Data
{
    public class Farkas_Szabolcs_ProiectExamenContext : DbContext
    {
        public Farkas_Szabolcs_ProiectExamenContext (DbContextOptions<Farkas_Szabolcs_ProiectExamenContext> options)
            : base(options)
        {
        }

        public DbSet<Farkas_Szabolcs_ProiectExamen.Models.Produs> Produs { get; set; } = default!;

        public DbSet<Farkas_Szabolcs_ProiectExamen.Models.Producator> Producator { get; set; }

        public DbSet<Farkas_Szabolcs_ProiectExamen.Models.Categorie> Categorie { get; set; }

        public DbSet<Farkas_Szabolcs_ProiectExamen.Models.Magazin> Magazin { get; set; }

        public DbSet<Farkas_Szabolcs_ProiectExamen.Models.Cumparator> Cumparator { get; set; }

        public DbSet<Farkas_Szabolcs_ProiectExamen.Models.Rezervare> Rezervare { get; set; }
    }
}
