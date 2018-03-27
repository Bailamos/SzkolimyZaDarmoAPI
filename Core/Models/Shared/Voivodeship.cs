using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("voivodeships")]
    public class Voivodeship
    {
        public int Id {get; set;}

        [Required]
        [MaxLength(64)]
        public string VoivodeshipName {get; set;}

        public ICollection<County> Counties {get; set;}

        public Voivodeship() {
            this.Counties = new Collection<County>();
        }
    }

}
