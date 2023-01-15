using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Farkas_Szabolcs_ProiectExamen.Models
{
    public class Rezervare
    {
        public int ID { get; set; }
        public int? CumparatorID { get; set; }
        public Cumparator? Cumparator { get; set; }
        public int? ProdusID { get; set; }
        public Produs? Produs { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datarezervarii { get; set; }
    }
}
