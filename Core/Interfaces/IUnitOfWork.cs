using System.Threading.Tasks;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}