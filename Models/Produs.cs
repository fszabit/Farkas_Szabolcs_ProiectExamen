using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Security.Policy;
using System.Xml.Linq;
namespace Farkas_Szabolcs_ProiectExamen.Models
{

   
    public class Produs
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Denumirea produsului")]
        public string? Denumire { get; set; }

        public string? Descriere { get; set; }
        public string? Origine { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Display(Name = "Pret")]
        public decimal? Price { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Display(Name = "Pret cu aplicatia Lidl Plus")]
        public decimal? Pret { get; set; }

        [Display(Name = "Numarul de bucati disponibile")]
        public uint NrBuc { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Valabil pana la data de")]
        public DateTime? Valabilitate { get; set; }

        public int? ProducatorID { get; set; }
        public Producator? Producator { get; set; }

    }
}
