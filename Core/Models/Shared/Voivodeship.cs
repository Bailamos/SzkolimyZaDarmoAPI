using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Szkolimy_za_darmo_api.Core.Interfaces;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("voivodeships")]
    public class Voivodeship : ICsvObject
    {
        public int Id {get; set;}

        [Required]
        [MaxLength(64)]
        public string VoivodeshipName {get; set;}

        public ICollection<County> Counties {get; set;}

        public Voivodeship() {
            this.Counties = new Collection<County>();
        }

        public string toCsv()
        {
            return this.VoivodeshipName;
        }
    }

}
