using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("counties")]
    public class County
    {
        public int Id {get; set;}

        [Required]
        [MaxLength(255)]
        public string CountyName {get; set;}

        public int VoivodeshipId {get; set;}

        public Voivodeship Voivodeship {get; set;}
    }

}
