namespace Szkolimy_za_darmo_api.Controllers.Resources.Query
{
    public class TrainingQueryResource
    {
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}