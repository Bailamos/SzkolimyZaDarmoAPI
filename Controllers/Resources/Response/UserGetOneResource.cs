using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Szkolimy_za_darmo_api.Controllers.Resources.Response;
using static Szkolimy_za_darmo_api.Controllers.Resources.Return.UserResource;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Return
{
    public partial class UserGetOneResource
    {
        public string PhoneNumber {get; set;}

        public string Name {get; set;}

        public string Surname {get; set;}

        public string Email {get; set;}

        public string CountyId {get; set;}

        public bool HasDisability {get; set;}

        public int BirthYear {get; set;}

        public DateTime LastUpdate {get; set;}

        public MarketStatusResource MarketStatus {get; set;}
        
        public AreaOfResidenceResource AreaOfResidence {get; set;}

        public EducationResource Education {get; set;}

        public SexResource Sex {get; set;}

        public VoivodeshipResource Voivodeship {get; set;}

        public CountyResource County {get; set;}

        public ICollection<EntryResource> Entries {get;set;}

        public ICollection<NoteResource> Notes {get; set;}
        
        public UserGetOneResource() {
            this.Entries = new Collection<EntryResource>();
            this.Notes = new Collection<NoteResource>();
        }
    }
}