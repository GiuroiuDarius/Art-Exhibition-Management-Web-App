using System.ComponentModel.DataAnnotations;

namespace test3.Models
{
    public class Categorii_de_bilete
    {
        [Key] public int Categorie_bilet_ID { get; set; }
        public string Denumire { get; set; }
        public int Pret { get; set; }
        public Categorii_de_bilete()
        {
            
        }
    }
}
