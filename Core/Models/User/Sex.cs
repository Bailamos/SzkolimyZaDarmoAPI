using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("sexes")]
    public class Sex
    {
        public int Id {get; set;}

        [Required]
        [MaxLength(16)]
        public string Name {get; set;}
    }
}