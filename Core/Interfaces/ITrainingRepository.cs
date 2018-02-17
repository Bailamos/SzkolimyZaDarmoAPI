using System.Threading.Tasks;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface ITrainingRepository
    {
        Task<Training> GetOne(int id, bool includeRelated = true);

        void Add(Training training);

        void Remove(Training training);
    }
}