namespace CRUDProject.Models.Domain
{
    public class TilføjMedarbejder
    {

       

        public string Navn { get; set; }

        public string Email { get; set; }

        public long Løn { get; set; }

        public DateTime PersonNummer { get; set; }

        public string Afdeling { get; set; }
    }
}
