using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveTrainingResource : IValidatableObject
    {
        public string Title {get; set;}
        public string Description {get; set;}
        public Nullable<DateTime> RegisterSince {get; set;}
        public Nullable<DateTime> RegisterTo {get; set;}
        public ICollection<string> Tags {get; set;}
        public string CategoryName {get; set;}
        public int MarketStatusId{get; set;}
        public int LocalizationId{get; set;}
        public int InstructorId {get; set;}

        public SaveTrainingResource() {
            this.Tags = new Collection<string>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RegisterSince > RegisterTo) {
                yield return new ValidationResult("Data zakonczenia szkolenia nie moze byc mniejsza od rozpoczecia");
            }
        }
    }
}