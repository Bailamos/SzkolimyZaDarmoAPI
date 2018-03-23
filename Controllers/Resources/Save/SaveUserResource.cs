using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveUserResource
    {
        [Required]
        public string PhoneNumber {get; set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public string Surname {get; set;}

        [Required]
        public string Email {get; set;}

        [Required]
        public int Age {get; set;}

        public int LocalizationId {get; set;}

        public int MarketStatusId {get; set;}

        public SaveEntryResource Entry {get; set;}
    }
}