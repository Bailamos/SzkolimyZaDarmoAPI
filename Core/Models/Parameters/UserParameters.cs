using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Szkolimy_za_darmo_api.Core.Models.Parameters
{
    public class UserParameters
    {
        public IEnumerable<MarketStatus> MarketStatuses {get; set;}

        public IEnumerable<Education> Educations {get; set;}

        public IEnumerable<Sex> Sexes {get; set;}

        public IEnumerable<AreaOfResidence> areasOfResidence {get; set;}

        public UserParameters() {
            this.MarketStatuses = new Collection<MarketStatus>();
            this.Educations = new Collection<Education>();
            this.Sexes = new Collection<Sex>();
            this.areasOfResidence = new Collection<AreaOfResidence>();
        }
    }
}