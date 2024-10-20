using System.ComponentModel.DataAnnotations;

namespace test3.Models
{
    public class Artisti
    {

        [Key] public int ArtistID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string CNP { get; set; }
        public string E_mail { get; set; }
        public string NrTelefon { get; set; }

        public Artisti()
        {
        }
    }
}
