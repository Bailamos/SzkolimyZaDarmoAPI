using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("areas_of_residence")]
    public class AreaOfResidence
    {
        public int Id {get; set;}

        [Required]
        [MaxLength(16)]
        public string AreaType {get; set;}
    }
}