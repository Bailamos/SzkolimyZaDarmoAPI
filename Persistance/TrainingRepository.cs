using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Persistance
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly SzdDbContext context;
        public TrainingRepository(SzdDbContext context)
        {
            this.context = context;
        }

        public void Add(Training training)
        {
            context.Trainings.Add(training);
        }

        public async Task<IEnumerable<Training>> GetAll()
        {
            var query = context.Trainings
                .Include(training => training.Types);
            var result = await query.ToListAsync();
            return result;
        }

        public async Task<Training> GetOne(int id, bool includeRelated = true)
        {
            return await context.Trainings
                .Include(training => training.Types)
                .SingleOrDefaultAsync(training => training.Id == id);
        }

        public void Remove(Training training)
        {
            throw new System.NotImplementedException();
        }
    }
}