using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("training_types")]
    public class TrainingType
    {
        public int TrainingId{get; set;}
        public string TypeName{get; set;}
        public Training Training {get; set;}
        public Type Type {get; set;}
    }
}