using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Farkas_Szabolcs_ProiectExamen.Models
{
    public class Magazin
    {
        public int ID { get; set; }

        [Display(Name = "Disponibil la magazinul")]
        public string NumeMagazin{ get; set; }
        public ICollection<Produs>? Produse { get; set; }
    }
}
