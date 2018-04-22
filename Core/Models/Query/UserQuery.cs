using Szkolimy_za_darmo_api.Extensions;

namespace Szkolimy_za_darmo_api.Core.Models.Query
{
    public class UserQuery : IQueryObject
    {

        public int[] MarketStatuses {get; set;}

        public int[] Localizations {get; set;}

        public string[] Categories {get; set;}

        public string SortBy {get; set;}
    
        public int? AgeFrom {get; set;}

        public int? AgeTo {get; set;}

        public bool IsSortAscending {get; set;}

        public int Page {get; set;}
        
        public int PageSize {get; set;}
    }
}