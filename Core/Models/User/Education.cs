using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("educations")]
    public class Education
    {
        public int Id {get; set;}

        [Required]
        [MaxLength(32)]
        public string EducationType {get; set;}
    }
}