using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Query;
using Szkolimy_za_darmo_api.Extensions;

namespace Szkolimy_za_darmo_api.Persistance
{
    public class UserRepository : IUserRepository
    {
         private readonly Dictionary<string, Expression<Func<User, object>>> COLUMNS_MAP 
            = new Dictionary<string, Expression<Func<User, object>>>()
        {
            ["Localization"] = v => v.County.CountyName,
            ["PhoneNumber"] = v => v.PhoneNumber,
            ["Name"] = v => v.Name,
            ["LastUpdate"] = v => v.LastUpdate
        };

        private readonly SzdDbContext context;

        public UserRepository(SzdDbContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public async Task<QueryResult<User>> GetAll(UserQuery queryObj, bool applyPaging = true) {
            var query = context.Users
                .Include(user => user.County)
                .Include(user => user.Sex)
                .Include(user => user.Education)
                .Include(user => user.AreaOfResidence)
                .Include(user => user.County)
                .Include(user => user.MarketStatus)
                .Include(user => user.Voivodeship)
                .Include(user => user.Entries)
                    .ThenInclude(entry => entry.Training)
                           .ThenInclude(training => training.Category)
                .AsQueryable();

            if (queryObj.AgeTo.HasValue)
                query = query.Where(v => queryObj.AgeTo > DateTime.Now.Year - v.BirthYear);             
            if (queryObj.AgeFrom.HasValue)
                query = query.Where(v => queryObj.AgeFrom < DateTime.Now.Year - v.BirthYear);  
            if (queryObj.Localizations.Length > 0)
                query = query.Where(
                    v => queryObj.Localizations.Contains(v.VoivodeshipId));              
            if (queryObj.MarketStatuses.Length > 0)
                query = query.Where(
                    v => queryObj.MarketStatuses.Contains(v.MarketStatusId));
            if (queryObj.Categories.Length > 0)
                query = query.Where(
                    v => v.Entries.Any(c => queryObj.Categories.Contains(c.Training.CategoryName)));



            int usersCount = query.ToList().Count();
            query = query.ApplyOrdering(queryObj, COLUMNS_MAP);
            if (applyPaging)
                query = query.ApplyPaging(queryObj);
                
            var users = await query.ToListAsync();

            var queryResult = new QueryResult<User>();
            queryResult.items = users;
            queryResult.itemsCount = usersCount;
            return queryResult;
             
        }
        public async Task<bool> CheckIfUserExists(string phoneNumber) {
            return await context.Users.AnyAsync(
                user => user.PhoneNumber == phoneNumber);
        }
        public async Task<User> GetOne(string phoneNumber)
        {
            return await context.Users
                .Include(user => user.Entries)
                    .ThenInclude(entry => entry.Training)
                      .ThenInclude(training => training.Category)
                .Include(user => user.Entries)
                    .ThenInclude(entry => entry.Training)
                      .ThenInclude(training => training.Localization)
                .Include(user => user.Entries)
                    .ThenInclude(entry => entry.Training)
                      .ThenInclude(training => training.MarketStatus)
                .Include(user => user.UserLogs)
                .Include(user => user.Comments)
                    .ThenInclude(c => c.Instructor)
                .Include(user => user.AreaOfResidence)
                .Include(user => user.County)
                .Include(user => user.Voivodeship)
                .Include(user => user.Education)
                .Include(user => user.MarketStatus)
                .Include(user => user.Sex)
                .SingleOrDefaultAsync(user => user.PhoneNumber == phoneNumber);
        }

        public void AddEntry(Entry entry)
        {
            context.Entries.Add(entry);
        }

        public async Task<bool> CheckIfEntryExists(int trainingId, string phoneNumber)
        {
            return await context.Entries.AnyAsync(
                entry => entry.UserPhoneNumber == phoneNumber && entry.TrainingId == trainingId);
        }

        public async Task<ICollection<UserLog>> GetUserLogs(string userPhoneNumber)
        {
            return await context.UserLog
                .Where(log => log.UserPhoneNumber == userPhoneNumber)
                .OrderByDescending(log => log.Date)
                .ToListAsync();
        }

        public void AddLog(UserLog log)
        {
            context.UserLog.Add(log);
        }
    }
}