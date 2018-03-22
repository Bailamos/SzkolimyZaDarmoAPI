using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Return
{
    public partial class InstructorResource {
        public int Id {get; set;}
        public string PhoneNumber {get; set;}
        public string Name {get; set;}
        public string Surname {get; set;}
        public string Email {get; set;}
        public bool IsActivated {get; set;}
        public bool IsAdmin {get; set;}
        public ICollection<InstructorTrainingResource> Trainings {get; set;}

        public InstructorResource() {
            this.Trainings = new Collection<InstructorTrainingResource>();
        }
    }
}