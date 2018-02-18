using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Szkolimy_za_darmo_api.Controllers.Resources
{
    public class TrainingResource
    {
        public int Id;
        public string Description {get; set;}
        public DateTime LastUpdate {get; set;}
        public ICollection<TrainingTypeResource> types {get; set;}

        public TrainingResource() {
            types = new Collection<TrainingTypeResource>();

        }
    }
}