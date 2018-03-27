using System.Collections.Generic;
using System.Threading.Tasks;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Parameters;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Voivodeship>> GetVoivodeships();

        Task<Voivodeship> GetVoivodeship(int id);

        Task<UserParameters> GetUserParameters();

        Task<TrainingParameters> GetTrainingParameters();
    }
}