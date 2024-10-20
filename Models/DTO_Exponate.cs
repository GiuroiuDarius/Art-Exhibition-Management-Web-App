using System.ComponentModel.DataAnnotations;

namespace test3.Models
{
    public class DTO_Exponate
    {
        [Key]public int ExponatId { get; set; }
        public string Nume_exponat { get; set; }
        public string Descriere { get; set; }
        public int An_fabricatie { get; set; }
        public int ExpozitieID { get; set; }
        public int ArtistID { get; set; }
        public int CategorieID { get; set; }
        
      //  public string Tipul_de_exponat { get; set; }

        public string Nume { get; set; }
    }
}
