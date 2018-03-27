using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        [Required]
        public string Password {get; set;}

        public bool IsActivated {get; set;}

        [Required]
        [DefaultValue(false)]
        public bool IsAdmin {get; set;}

        public ICollection<Training> Trainings {get; set;}

        public ICollection<Reminder> Reminders {get; set;}

        public Instructor(){
            this.Trainings = new Collection<Training>();
            this.Reminders = new Collection<Reminder>();
        }
    }
}