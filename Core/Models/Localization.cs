using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("localizations")]
    public class Localization
    {
        public int Id {get; set;}
        public string voivodeship {get; set;}
    }
}