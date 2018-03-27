using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
     [Table("training_marketstatuses")]
    public class TrainingMarketStatus
    {
        public int TrainingId{get; set;}
        public int MarketStatusId {get; set;}
        public Training Training {get; set;}
        public MarketStatus MarketStatus {get; set;}
    }
}