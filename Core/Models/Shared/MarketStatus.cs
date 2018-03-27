using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("marketStatuses")]
    public class MarketStatus
    {
        public int Id {get; set;}

        [MaxLength(255)]
        public string Status {get; set;}
    
        ICollection<Training> trainings {get; set;}

        public MarketStatus() {
            this.trainings = new Collection<Training>();
        }
    }
}