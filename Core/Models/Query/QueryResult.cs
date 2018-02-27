using System.Collections.Generic;

namespace Szkolimy_za_darmo_api.Core.Models.Query
{
    public class QueryResult<TItem>
    {
        public IEnumerable<TItem> items {get; set;}
        public int itemsCount{get; set;}
    }
}