using System.Collections.Generic;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Query
{
    public class QueryResultResource<TItem>
    {
        public IEnumerable<TItem> items {get; set;}
        public int itemsCount{get; set;}
    }
}