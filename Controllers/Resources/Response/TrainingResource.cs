using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Return
{
    public partial class TrainingResource
    {
        public int Id;
        public string Title {get; set;}
        public string Description {get; set;}
        public DateTime LastUpdate {get; set;}
        public DateTime InsertDate {get; set;}
        public DateTime RegisterSince {get; set;}
        public DateTime RegisterTo {get; set;}
        public ICollection<TagResource> Tags {get; set;}
        public CategoryResource Category {get; set;}
        public MarketStatusResource MarketStatus {get; set;}
        public LocalizationResource Localization {get; set;}
        public InstructorResource Instructor {get; set;}
        public TrainingResource() {
            Tags = new Collection<TagResource>();
        }
    }
}