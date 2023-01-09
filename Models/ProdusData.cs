namespace Farkas_Szabolcs_ProiectExamen.Models
{
    public class ProdusData
    {
        public IEnumerable<Produs> Produse { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<ProdusCategorie> ProdusCategorii { get; set; }

    }
}
