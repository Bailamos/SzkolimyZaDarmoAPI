using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Szkolimy_za_darmo_api.Core.Interfaces;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("areas_of_residence")]
    public class AreaOfResidence : ICsvObject
    {
        public int Id {get; set;}

        [Required]
        [MaxLength(16)]
        public string AreaType {get; set;}

        public string toCsv()
        {
            return this.AreaType;
        }
    }
}