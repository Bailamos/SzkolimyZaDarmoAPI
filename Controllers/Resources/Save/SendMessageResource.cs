using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources
{
    public class SendMessageResource
    {
        [Required]
        public string[] Receivers {get; set;}
        
        [Required]
        public string Message {get; set;}

        public string Subject {get; set;}
    }
}