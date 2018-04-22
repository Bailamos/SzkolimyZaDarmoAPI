using System.Collections.Generic;

namespace Szkolimy_za_darmo_api.Core.Models.Parameters
{
    public class TrainingParameters
    {
        public IEnumerable<MarketStatus> MarketStatuses {get; set;}

        public IEnumerable<Category> Categories {get; set;}

        public IEnumerable<Voivodeship> Voivodeships {get; set;}
    }
}