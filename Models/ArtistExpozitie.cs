using System.ComponentModel.DataAnnotations;

namespace test3.Models
{
    public class ArtistExpozitie
    {
        [Key]public int ArtistID { get; set; }
        [Key]public int ExpozitieID { get; set; }
        public ArtistExpozitie()
        {
            
        }
    }
}
