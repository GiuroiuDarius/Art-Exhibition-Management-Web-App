using System.ComponentModel.DataAnnotations;

namespace test3.Models
{
    public class Vizitatori
    {

        [Key] public int VizitatorID { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public  string CNP { get; set; }
        public string E_mail { get; set; }
        public string NrTelefon { get; set; }

        public Vizitatori()
        {
            
        }



    }
}
