using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Farkas_Szabolcs_ProiectExamen.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [Display(Name = "Categorie")]
        public string NumeCategorie { get; set; }
        public ICollection<ProdusCategorie>? ProdusCategorii { get; set; }
    }
}
