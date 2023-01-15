using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Farkas_Szabolcs_ProiectExamen.Models
{
    public class Cumparator
    {
        public int ID { get; set; }
        public string? Nume { get; set; }
        public string? Prenume { get; set; }
        public string? Adresa { get; set; }
        public string Email { get; set; }
        public string? NrTel { get; set; }
        [Display(Name = "Numele clientului")]
        public string? FullName
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Rezervare>? Rezervari { get; set; }
    }

}

