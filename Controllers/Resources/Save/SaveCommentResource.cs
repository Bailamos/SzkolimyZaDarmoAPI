using System;
using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveCommentResource
    {
        [Required]
        public string Description {get; set;}

        [Required]
        public string UserPhoneNumber{get; set;}

        [Required]
        public int InstructorId {get; set;}
    }
}