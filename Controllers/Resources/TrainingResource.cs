using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Szkolimy_za_darmo_api.Controllers.Resources
{
    public class TrainingResource
    {
        public int Id;
        public string Title {get; set;}
        public string Description {get; set;}
        public DateTime LastUpdate {get; set;}
        public DateTime InsertDate {get; set;}
        public DateTime RegisterSince {get; set;}
        public DateTime RegisterTo {get; set;}
        public ICollection<TypeResource> Types {get; set;}
        public TypeResource MainType {get; set;}
        public MarketStatusResource MarketStatus{get; set;}
        public TrainingResource() {
            Types = new Collection<TypeResource>();
        }
    }
}