using Szkolimy_za_darmo_api.Extensions;

namespace Szkolimy_za_darmo_api.Core.Models.Query
{
    public class TrainingQuery : IQueryObject
    {
        public int? InstructorId {get; set;}
        public string[] Categories {get; set;}
        public int[] Localizations {get; set;}
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}