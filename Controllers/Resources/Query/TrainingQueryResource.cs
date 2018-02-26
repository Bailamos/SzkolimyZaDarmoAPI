using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Query
{
    public class TrainingQueryResource
    {
        public string Localizations { get; set; }
        public string Categories { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public TrainingQueryResource() {
            // categories = new Collection<string>();
        }
    }
}