using System;
using System.ComponentModel.DataAnnotations;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveUserResource
    {
        [Required]
        public string PhoneNumber {get; set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public string Surname {get; set;}

        [Required]
        public string Email {get; set;}

        [Required]
        public DateTime BirthDay {get; set;}

        [Required]
        public int? MarketStatusId {get; set;}
        
        [Required]
        public int? AreaOfResidenceId {get; set;}

        [Required]
        public int? EducationId {get; set;}

        [Required]
        public int? SexId {get; set;}

        public int? CountyId {get; set;}

        [Required]
        public int? VoivodeshipId {get; set;}

        [Required]
        public bool? HasDisability {get; set;}

        public SaveEntryResource Entry {get; set;}

        public SaveNoteResource Note {get; set;}
     
    }
}