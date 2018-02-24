using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly SzdDbContext context;

        public UserRepository(SzdDbContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }
        
        public async Task<bool> CheckIfUserExists(string phoneNumber) {
            return await context.Users.AnyAsync(user => user.PhoneNumber == phoneNumber);
        }
        public async Task<User> GetOne(string phoneNumber, bool includeRelated = true)
        {
            return await context.Users.SingleOrDefaultAsync(user => user.PhoneNumber == phoneNumber);
        }

        public void Remove(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<Entry> AddEntry(int userId, int trainingId)
        {
            throw new System.NotImplementedException();
        }

        public void AddEntry(Entry entry)
        {
            context.Entries.Add(entry);
        }
    }
}