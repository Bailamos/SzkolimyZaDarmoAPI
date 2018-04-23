using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("entries")]
    public class Entry
    {

        public string UserPhoneNumber{get; set;}

        public int TrainingId{get; set;}

        public DateTime InsertDate{get; set;}

        [Required]
        public bool? DidParticipated {get; set;}

        public Training Training {get; set;}
        
        public User user {get; set;}
    }
}