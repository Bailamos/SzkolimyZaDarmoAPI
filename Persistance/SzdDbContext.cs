using Microsoft.EntityFrameworkCore;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Persistance
{
    public class SzdDbContext : DbContext
    {
        public DbSet<Training> Trainings {get; set;}

        public DbSet<Type> Types {get; set;}

        public SzdDbContext(DbContextOptions<SzdDbContext> options) : base(options) {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TrainingType>().HasKey(TrainingType => new {
                    TrainingType.TrainingId,
                    TrainingType.TypeName
                });
        }
    }
}