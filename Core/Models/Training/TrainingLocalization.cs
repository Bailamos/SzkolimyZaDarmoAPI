using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("training_localizations")]
    public class TrainingLocalization
    {
        public int TrainingId{get; set;}
        public int CountyId {get; set;}
        public Training Training {get; set;}
        public County County {get; set;}
    }
}