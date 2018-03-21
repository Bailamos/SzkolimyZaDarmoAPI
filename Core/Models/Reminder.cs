using System;

namespace Szkolimy_za_darmo_api.Core.Models
{
    public class Reminder
    {
        public int Id {get; set;}
        public string UserPhoneNumber{get; set;}
        public int InstructorId{get; set;}
        public User User {get; set;}
        public Instructor Instructor {get; set;}
        public string Description {get; set;}
        public DateTime DueDate {get; set;}
    }
}