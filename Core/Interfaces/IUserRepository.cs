using System.Collections.Generic;
using System.Threading.Tasks;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Query;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<QueryResult<User>> GetAll(UserQuery queryObj, bool applyPaging = true);

        Task<User> GetOne(string id);

        void Add(User user);

        Task<bool> CheckIfUserExists(string phoneNumber);

        void AddEntry(Entry entry);

        Task<bool> CheckIfEntryExists(int trainingId, string phoneNumber);

        Task<ICollection<UserLog>> GetUserLogs(string userId);
    
    }
}