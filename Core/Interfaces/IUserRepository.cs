using System.Collections.Generic;
using System.Threading.Tasks;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetOne(string id, bool includeRelated = true);

        void Add(User user);

        void Remove(User user);

        Task<IEnumerable<User>> GetAll();

        Task<bool> CheckIfUserExists(string phoneNumber);

        void AddEntry(Entry entry);
    }
}