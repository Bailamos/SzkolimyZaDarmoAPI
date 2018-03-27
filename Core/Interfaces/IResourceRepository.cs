using System.Collections.Generic;
using System.Threading.Tasks;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Parameters;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface IResourceRepository
    {
        Task<IEnumerable<Voivodeship>> getVoivodeships();

        Task<Voivodeship> getVoivodeship(int id);

        Task<UserParameters> getUserParameters();
    }
}