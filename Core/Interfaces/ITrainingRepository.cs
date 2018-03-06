using System.Collections.Generic;
using System.Threading.Tasks;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Query;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface ITrainingRepository
    {
        Task<Training> GetOne(int id, bool includeRelated = true);

        void Add(Training training);

        void Remove(Training training);

        Task<QueryResult<Training>> GetAll(TrainingQuery trainingQuery);

        Task<IEnumerable<Category>> GetAllCategories();
        
        Task<IEnumerable<Localization>> GetAllLocalizations();

        Task<IEnumerable<MarketStatus>> GetAllStatuses();

        void UpdateTags(Training training);

    }
}