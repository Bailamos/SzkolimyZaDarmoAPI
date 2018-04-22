namespace Szkolimy_za_darmo_api.Controllers.Resources.Query
{
    public class UserQueryResource
    {

        public string Localizations {get; set;}

        public string Categories {get; set;}

        public string MarketStatuses {get; set;}

        public string SortBy {get; set;}

        public int? AgeFrom {get; set;}

        public int? AgeTo {get; set;}

        public bool IsSortAscending {get; set;}

        public int Page {get; set;}
        
        public int PageSize {get; set;}
    }
}