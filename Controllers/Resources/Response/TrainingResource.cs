using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Szkolimy_za_darmo_api.Controllers.Resources.Response;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Return
{
    public partial class TrainingResource
    {
        public int Id;

        public string Title {get; set;}

        public string Description {get; set;}

        public string ContactEmail {get; set;}

        public string ContactPhoneNumber {get; set;}

        public DateTime LastUpdate {get; set;}

        public DateTime InsertDate {get; set;}

        public DateTime RegisterSince {get; set;}

        public DateTime RegisterTo {get; set;}

        public ICollection<TagResource> Tags {get; set;}

        public CategoryResource Category {get; set;}

        public MarketStatusResource MarketStatus {get; set;}
    
        public TrainingInstructorResource Instructor {get; set;}

        public VoivodeshipResource Voivodeship {get; set;}

        public ICollection<MarketStatusResource> MarketStatuses {get; set;}

        public ICollection<CountyResource> Counties {get; set;}

        public int InstructorId {get; set;}
        public TrainingResource() {
            this.Tags = new Collection<TagResource>();
            this.MarketStatuses = new Collection<MarketStatusResource>();
            this.Counties = new Collection<CountyResource>();
        }

        public class VoivodeshipResource {
            public int Id {get; set;}  
            public string VoivodeshipName {get; set;}
        }
    }
}