using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveTrainingResource
    {
        public string Description {get; set;}
        public ICollection<int> Types {get; set;}

        public SaveTrainingResource() {
            this.Types = new Collection<int>();
        }
    }
}