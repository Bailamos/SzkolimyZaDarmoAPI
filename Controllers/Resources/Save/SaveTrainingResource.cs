using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveTrainingResource
    {
        public string Title {get; set;}
        public string Description {get; set;}
        public Nullable<DateTime> RegisterSince {get; set;}
        public Nullable<DateTime> RegisterTo {get; set;}
        public ICollection<string> Types {get; set;}
        public string MainTypeName {get; set;}
        public int MarketStatusId{get; set;}
        public int LocalizationId{get; set;}
        public SaveTrainingResource() {
            this.Types = new Collection<string>();
        }
    }
}