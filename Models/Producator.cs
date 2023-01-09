using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Farkas_Szabolcs_ProiectExamen.Models
{
    public class Producator
    {
        public int ID { get; set; }

        [Display(Name = "Producatorul")]
        public string? NumeProducator { get; set; }
        public ICollection<Produs>? Produse { get; set; }
    }
}
