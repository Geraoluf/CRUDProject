namespace CRUDProject.Models.ViewModels
{
    public class UpdateViewModel
    {

        public Guid Id { get; set; }

        public string Navn { get; set; }

        public string Email { get; set; }

        public long Løn { get; set; }

        public DateTime PersonNummer { get; set; }

        public string Afdeling { get; set; }
    }
}
