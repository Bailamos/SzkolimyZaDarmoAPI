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
    public class TrainingRepository : ITrainingRepository
    {
        private readonly Dictionary<string, Expression<Func<Training, object>>> COLUMNS_MAP 
            = new Dictionary<string, Expression<Func<Training, object>>>()
        {
            ["LastUpdate"] = v => v.LastUpdate,
        };

        private readonly SzdDbContext context;

        public TrainingRepository(SzdDbContext context)
        {
            this.context = context;
        }

        public void Add(Training training)
        {
            context.Trainings.Add(training);
        }

        public async Task<IEnumerable<Training>> GetAll(TrainingQuery queryObj)
        {
            var query = context.Trainings
                .Include(training => training.MarketStatus)
                .Include(training => training.Category)
                .Include(training => training.Tags)
                .Include(training => training.Localization)
                .AsQueryable();

            // if (queryObj.Category.HasValue)
            //     query = query.Where(v => v.Category.Id == queryObj.Category.Value);

            query = query.ApplyOrdering(queryObj, COLUMNS_MAP);
            query = query.ApplyPaging(queryObj);

            var result = await query.ToListAsync();
            return result;
        }

        public async Task<Training> GetOne(int id, bool includeRelated = true)
        {
            if(includeRelated)
                return await context.Trainings
                    .Include(training => training.MarketStatus)
                    .Include(training => training.Category)
                    .Include(training => training.Tags)
                    .Include(training => training.Localization)
                    .SingleOrDefaultAsync(training => training.Id == id);
            else
                return await context.Trainings
                    .SingleOrDefaultAsync(training => training.Id == id);
        }

        public void Remove(Training training)
        {
            throw new System.NotImplementedException();
        }
    }
}