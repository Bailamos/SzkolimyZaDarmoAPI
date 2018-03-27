using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveTrainingResource : IValidatableObject
    {
        [Required]
        public string Title {get; set;}

        [Required]
        public string Description {get; set;}

        public Nullable<DateTime> RegisterSince {get; set;}

        public Nullable<DateTime> RegisterTo {get; set;}

        [Required]
        public string CategoryName {get; set;}

        [Required]
        public int? MarketStatusId{get; set;}

        [Required]
        public int? LocalizationId{get; set;}

        [Required]
        public int? InstructorId {get; set;}

        [Required]
        public int? VoivodeshipId {get; set;}

        public ICollection<int> Counties {get; set;}

        public ICollection<int> MarketStatuses {get; set;}
        
        public ICollection<string> Tags {get; set;}

        public SaveTrainingResource() {
            this.Tags = new Collection<string>();
            this.Counties = new Collection<int>();
            this.MarketStatuses = new Collection<int>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RegisterSince > RegisterTo) {
                yield return new ValidationResult("Data zakonczenia szkolenia nie moze byc mniejsza od rozpoczecia");
            }
        }
    }
}