using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Szkolimy_za_darmo_api.Controllers.Resources.Response;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Return
{
    public partial class UserResource
    {
        public string PhoneNumber {get; set;}

        public string Name {get; set;}

        public string Surname {get; set;}

        public string Email {get; set;}

        public string LocalizationId {get; set;}

        public bool HasDisability {get; set;}

        public DateTime LastUpdate {get; set;}

        public MarketStatusResource MarketStatus {get; set;}
        
        public AreaOfResidenceResource AreaOfResidence {get; set;}

        public EducationResource Education {get; set;}

        public SexResource Sex {get; set;}

        public ICollection<EntryResource> Entries {get;set;}
        
        public UserResource() {
            this.Entries = new Collection<EntryResource>();
        }
    }
}