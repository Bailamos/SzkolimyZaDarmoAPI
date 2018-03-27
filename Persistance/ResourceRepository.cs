using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Szkolimy_za_darmo_api.Core.Interfaces;
using Szkolimy_za_darmo_api.Core.Models;
using Szkolimy_za_darmo_api.Core.Models.Parameters;

namespace Szkolimy_za_darmo_api.Persistance
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly SzdDbContext context;
        public ResourceRepository(SzdDbContext context)
        {
            this.context = context;
        }

        public async Task<TrainingParameters> GetTrainingParameters()
        {
            var categories = await this.context.Categories.ToListAsync();
            var marketStatuses = await this.context.MarketStatuses.ToListAsync();

            var trainingParameters = new TrainingParameters();
            trainingParameters.Categories = categories;
            trainingParameters.MarketStatuses = marketStatuses;

            return trainingParameters;
        }

        public async Task<UserParameters> GetUserParameters()
        {
            var marketStatuses = await this.context.MarketStatuses.ToListAsync();
            var sexes = await this.context.Sexes.ToListAsync();
            var educations = await this.context.Educations.ToListAsync();
            var areasOfResidence = await this.context.AreasOfResidence.ToListAsync();

            var userParameters = new UserParameters();
            userParameters.MarketStatuses = marketStatuses;
            userParameters.Sexes = sexes;
            userParameters.Educations = educations;
            userParameters.areasOfResidence = areasOfResidence;

            return userParameters;
        }

        public async Task<Voivodeship> GetVoivodeship(int id)
        {
            return await this.context.Voivodeships
                .Include(v => v.Counties)
                .SingleOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Voivodeship>> GetVoivodeships()
        {
            return  await this.context.Voivodeships.ToListAsync();
        }

        
    }
}