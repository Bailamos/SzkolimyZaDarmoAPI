using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Szkolimy_za_darmo_api.Core.Interfaces;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("counties")]
    public class County : ICsvObject
    {
        public int Id {get; set;}

        [Required]
        [MaxLength(255)]
        public string CountyName {get; set;}

        public int VoivodeshipId {get; set;}

        public Voivodeship Voivodeship {get; set;}

        public string toCsv()
        {
            return this.CountyName;
        }
    }

}
