using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    public class UserLog
    {
        public int Id {get; set;}
        
        [Required]
        public string PropertyName { get; set; }

        [Required]
        public DateTime ChangeDate {get; set;}

        [Required]
        [MaxLength(255)]
        public string OldValue { get; set; }

        [Required]
        [MaxLength(255)]
        public string NewValue { get; set; }

        [Required]
        [MaxLength(255)]
        public string ByWho {get; set;}

        public User User {get; set;}

        [Required]
        public string UserPhoneNumber{get; set;}
    }
}