using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Query;

namespace Szkolimy_za_darmo_api.Persistance
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly SzdDbContext context;

        public InstructorRepository(SzdDbContext context)
        {
            this.context = context;
        }

        public async Task<Instructor> LogIn(string email, string password) {
            return await this.context.Instructors
                .Where(instructor => instructor.Email == email && instructor.Password == password)
                .SingleOrDefaultAsync();

        }

        public void Add(Instructor instructor)
        {
           context.Instructors.Add(instructor);
        }

        public async Task<QueryResult<Instructor>> GetAll()
        {
            var query = context.Instructors.AsQueryable();
            int instructorsCount = query.ToList().Count();
            var instructors = await query.ToListAsync();

            var queryResult = new QueryResult<Instructor>();
            queryResult.items = instructors;
            queryResult.itemsCount = instructorsCount;

            return queryResult;
        }

        public async Task<Instructor> GetOne(int id)
        {
            return await context.Instructors
                .Include(instructor => instructor.Trainings)
                    .ThenInclude(training => training.Category)
                .Include(instructor => instructor.Trainings)
                    .ThenInclude(training => training.MarketStatus)
                .Include(instructor => instructor.Trainings)
                    .ThenInclude(training => training.Tags)
                .Include(instructor => instructor.Trainings)
                    .ThenInclude(training => training.Localization)
                .Include(instructor => instructor.Reminders)
                .SingleOrDefaultAsync(instructor => instructor.Id == id);
        }


        public void Remove(Instructor instructor) {
            context.Instructors.Remove(instructor);
        }

        public void AddReminder(Reminder reminder)
        {
            context.Reminders.Add(reminder);
        }

        public void RemoveReminder(Reminder reminder)
        {
           context.Reminders.Remove(reminder);
        }

        public async Task<Reminder> GetReminder(int id)
        {
            return await context.Reminders.SingleOrDefaultAsync(reminder => reminder.Id == id);
        }
    }
}