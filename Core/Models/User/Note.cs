using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("notes")]
    public class Note
    {
        public int Id {get; set;}

        [Required]
        [MaxLength(1000)]
        public string Description{get; set;}

        [Required]
        public string UserPhoneNumber {get; set;}

        public User User {get; set;}
    }
}