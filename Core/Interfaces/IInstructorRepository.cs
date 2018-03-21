using System.Collections.Generic;
using System.Threading.Tasks;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Query;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface IInstructorRepository
    {
        void Add(Instructor instructor);

        Task<Instructor> GetOne(int id);

        Task<QueryResult<Instructor>> GetAll();

        void Remove(Instructor instructor);

        void AddReminder(Reminder reminder);

        void RemoveReminder(Reminder reminder);

        Task<Reminder> GetReminder(int id);
    }
}