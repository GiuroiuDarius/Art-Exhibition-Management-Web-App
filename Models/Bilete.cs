using System.ComponentModel.DataAnnotations;

namespace test3.Models
{
    public class Bilete
    {
        [Key]public int BiletID { get; set; }
        public DateTime Data_achizitionarii { get; set; }
        public DateTime Valabilitate { get; set; }
        public int ExpozitieID { get; set; }
        public int VizitatorID { get; set; }
        public int Categorie_bilet_ID { get; set; }

        public Bilete()
        {
            
        }



    }
}
