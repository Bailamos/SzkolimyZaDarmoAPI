using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("instructors")]
    public class Instructor
    {
        public int Id {get; set;}
        [Required]
        public string PhoneNumber {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Surname {get; set;}
        [Required]
        public string Email {get; set;}
        public ICollection<Training> Trainings {get; set;}

        public Instructor(){
            Trainings = new Collection<Training>();
        }
    }
}