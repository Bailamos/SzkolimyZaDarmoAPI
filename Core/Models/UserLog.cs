using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    public class UserLog
    {
        public int Id {get; set;}
        [Required]
        public string Description {get; set;}
        public DateTime Date {get; set;}
        public User User {get; set;}
        [Required]
        public string UserPhoneNumber{get; set;}
    }
}