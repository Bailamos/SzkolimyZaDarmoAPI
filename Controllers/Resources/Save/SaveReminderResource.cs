using System;
using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveReminderResource
    {
        [Required]
        public string Description {get; set;}
        [Required]
        public DateTime DueDate {get; set;}
    }
}