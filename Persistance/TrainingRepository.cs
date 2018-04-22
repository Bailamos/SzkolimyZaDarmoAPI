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
            ["InsertDate"] = v => v.InsertDate,
            ["Category"] = v => v.Category.Name,
            ["Localization"] = v => v.Localization.voivodeship,
            ["RegisterTo"] = v => v.RegisterTo,
        };

        private readonly SzdDbContext context;

        public TrainingRepository(SzdDbContext context)
        {
            this.context = context;
        }

        public void Add(Training training)
        {
            foreach (TrainingTag trainingTag in training.Tags) {
                if (!context.Tags.Any(tag => tag.Name == trainingTag.TagName)) {
                    context.Tags.Add(new Tag{Name = trainingTag.TagName});
                }
            }

            context.Trainings.Add(training);
        }

        public async Task<QueryResult<Training>> GetAll(TrainingQuery queryObj)
        {
            var query = context.Trainings
                .Include(training => training.MarketStatus)
                .Include(training => training.Category)
                .Include(training => training.Tags)
                .Include(training => training.Voivodeship)
                .AsQueryable();

            if (queryObj.Categories.Length > 0)
                 query = query.Where(v => queryObj.Categories.Contains(v.Category.Name));
            if (queryObj.Localizations.Length > 0)
                 query = query.Where(v => queryObj.Localizations.Contains(v.Voivodeship.Id));
            if (queryObj.InstructorId.HasValue)
                 query = query.Where(v => queryObj.InstructorId == v.InstructorId);

            int trainingsCount = query.ToList().Count();
            query = query.ApplyOrdering(queryObj, COLUMNS_MAP);
            query = query.ApplyPaging(queryObj);
            var trainings = await query.ToListAsync();

            var queryResult = new QueryResult<Training>();
            queryResult.items = trainings;
            queryResult.itemsCount = trainingsCount;
            return queryResult;
        }

        public async Task<Training> GetOne(int id, bool includeRelated = true)
        {
            if(includeRelated)
                return await context.Trainings
                    .Include(training => training.MarketStatus)
                    .Include(training => training.Category)
                    .Include(training => training.Tags)
                    .Include(training => training.Voivodeship)
                    .Include(training => training.Instructor)
                    .Include(training => training.Counties)
                        .ThenInclude(trainingCounty => trainingCounty.County)
                    .Include(training => training.MarketStatuses)
                        .ThenInclude(marketStatuses => marketStatuses.MarketStatus)
                    .SingleOrDefaultAsync(training => training.Id == id);
            else
                return await context.Trainings
                    .SingleOrDefaultAsync(training => training.Id == id);
        }

        public void Remove(Training training)
        {
            context.Trainings.Remove(training);
        }

        public void UpdateTags(Training training) {
            foreach (TrainingTag trainingTag in training.Tags) {
                if (!context.Tags.Any(tag => tag.Name == trainingTag.TagName)) {
                    context.Tags.Add(new Tag{Name = trainingTag.TagName});
                }
            }
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<Localization>> GetAllLocalizations()
        {
            return await context.Localizations.ToListAsync();
        }

        public async Task<IEnumerable<MarketStatus>> GetAllStatuses()
        {
            return await context.MarketStatuses.ToListAsync();
        }
    }
}