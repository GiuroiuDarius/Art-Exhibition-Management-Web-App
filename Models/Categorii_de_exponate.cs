using System.ComponentModel.DataAnnotations;

namespace test3.Models
{
    public class Categorii_de_exponate
    {
        [Key] public int CategorieID { get; set; }
        public string Tipul_de_exponat { get; set; }

        public Categorii_de_exponate()
        {
            
        }
    }
}
