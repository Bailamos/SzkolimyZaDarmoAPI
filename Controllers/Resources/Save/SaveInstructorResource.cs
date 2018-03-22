using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveInstructorResource
    {
        [RegularExpression("^(\\d{7}|\\d{9})$")]
        public string PhoneNumber {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Surname {get; set;}

        [RegularExpression(
            "^((([!#$%&'*+\\-/=?^_`{|}~\\w])|([!#$%&'*+\\-/=?^_`{|}~\\w]"
             + "[!#$%&'*+\\-/=?^_`{|}~\\.\\w]{0,}[!#$%&'*+\\-/=?^_`{|}~\\w]))"
             + "[@]\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)$")]
        public string Email {get; set;}

        [Required]
        public string Password {get; set;}
    }
}