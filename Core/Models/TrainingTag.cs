using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("training_tags")]
    public class TrainingTag
    {
        public int TrainingId{get; set;}
        public string TagName{get; set;}
        public Training Training {get; set;}
        public Tag Tag {get; set;}
    }
}