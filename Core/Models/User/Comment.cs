using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("comments")]
    public class Comment
    {
        public int Id {get; set;}

        [Required]
        public string Description {get; set;}

        public DateTime Date {get; set;}

        public User User {get; set;}

        public string UserPhoneNumber{get; set;}
        
        public Instructor Instructor {get; set;}

        public int InstructorId {get; set;}
    }
}