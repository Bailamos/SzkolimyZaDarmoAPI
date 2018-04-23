using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Szkolimy_za_darmo_api.Core.Interfaces;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("educations")]
    public class Education : ICsvObject
    {
        public int Id {get; set;}

        [Required]
        [MaxLength(32)]
        public string EducationType {get; set;}

        public string toCsv()
        {
            return this.EducationType;
        }
    }
}