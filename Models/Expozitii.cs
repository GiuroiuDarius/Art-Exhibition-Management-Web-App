using System.ComponentModel.DataAnnotations;

namespace test3.Models
{
    public class Expozitii
    {
        [Key] public int ExpozitieID { get; set; }
        public string Nume_expozitie { get; set; }
        public int Numar_exponate { get; set; }
        public int Numar_vizitatori { get; set; }
        public string Tema_expozitiei { get; set; }
        public DateTime Data_inceperii { get; set; }
        public DateTime Data_incheierii { get; set; }
        public string Locatie { get; set; }

        public Expozitii()
        {
            
        }


    }
}
