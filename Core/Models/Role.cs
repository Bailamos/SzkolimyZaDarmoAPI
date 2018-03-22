using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("roles")]
    public class Role
    {
        public int Id {get; set;}
        [Required]
        public string RoleName {get; set;}
    }
}