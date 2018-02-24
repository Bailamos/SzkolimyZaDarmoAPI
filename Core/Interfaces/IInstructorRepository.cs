using System.Threading.Tasks;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface IInstructorRepository
    {
        void Add(Instructor instructor);

        Task<Instructor> GetOne(int id);
    }
}