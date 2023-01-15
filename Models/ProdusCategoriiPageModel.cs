using Microsoft.AspNetCore.Mvc.RazorPages;
using Farkas_Szabolcs_ProiectExamen.Data;


namespace Farkas_Szabolcs_ProiectExamen.Models
{
    public class ProdusCategoriiPageModel : PageModel
    {
        public List<AssignedCategorieData> AssignedCategorieDataList;
        public void PopulateAssignedCategorieData(Farkas_Szabolcs_ProiectExamenContext context,Produs produs)
        {
            var allCategorii = context.Categorie;
            var produsCategorii = new HashSet<int>(
            produs.ProdusCategorii.Select(c => c.CategorieID)); 
            AssignedCategorieDataList = new List<AssignedCategorieData>();
            foreach (var cat in allCategorii)
            {
                AssignedCategorieDataList.Add(new AssignedCategorieData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Assigned = produsCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateProdusCategorii(Farkas_Szabolcs_ProiectExamenContext context,
        string[] selectedCategorii, Produs produsToUpdate)
        {
            if (selectedCategorii == null)
            {
                produsToUpdate.ProdusCategorii = new List<ProdusCategorie>();
                return;
            }
            var selectedCategoriiHS = new HashSet<string>(selectedCategorii);
            var produsCategorii = new HashSet<int>
            (produsToUpdate.ProdusCategorii.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriiHS.Contains(cat.ID.ToString()))
                {
                    if (!produsCategorii.Contains(cat.ID))
                    {
                        produsToUpdate.ProdusCategorii.Add(
                        new ProdusCategorie
                        {
                            ProdusID = produsToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (produsCategorii.Contains(cat.ID))
                    {
                        ProdusCategorie courseToRemove
                        = produsToUpdate
                        .ProdusCategorii
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
