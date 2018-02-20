using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveTrainingResource
    {
        public string Description {get; set;}
        public DateTime RegisterSince {get; set;}
        public DateTime RegisterTo {get; set;}
        public ICollection<string> Types {get; set;}

        public SaveTrainingResource() {
            this.Types = new Collection<string>();
        }
    }
}