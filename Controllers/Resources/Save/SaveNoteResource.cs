using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveNoteResource
    {
        [Required]
        public string Description{get; set;}
    }
}