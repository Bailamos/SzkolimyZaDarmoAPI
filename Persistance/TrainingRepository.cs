using System.Threading.Tasks;
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

        public async Task<Training> GetOne(int id, bool includeRelated = true)
        {
            return await context.Trainings.FindAsync(id);
        }

        public void Remove(Training training)
        {
            throw new System.NotImplementedException();
        }
    }
}