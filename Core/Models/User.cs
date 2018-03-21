using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(16)]
        public string PhoneNumber {get; set;}
        [Required]
        public string Name {get; set;}
        [Required]
        public string Surname {get; set;}
        public ICollection<Entry> Entries {get; set;}
        public User(){
            this.Entries = new Collection<Entry>();
        }

    }
}