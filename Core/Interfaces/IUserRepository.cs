using System.Collections.Generic;
using System.Threading.Tasks;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetOne(string id);

        void Add(User user);

        Task<bool> CheckIfUserExists(string phoneNumber);

        void AddEntry(Entry entry);

        Task<bool> CheckIfEntryExists(int trainingId, string phoneNumber);
    }
}