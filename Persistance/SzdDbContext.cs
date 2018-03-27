using Microsoft.EntityFrameworkCore;
using Szkolimy_za_darmo_api.Core.Models;

namespace Szkolimy_za_darmo_api.Persistance
{
    public class SzdDbContext : DbContext
    {
        public DbSet<MarketStatus> MarketStatuses {get; set;}
        public DbSet<Training> Trainings {get; set;}
        public DbSet<Localization> Localizations {get; set;}
        public DbSet<Tag> Tags {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<Entry> Entries {get; set;}
        public DbSet<Instructor> Instructors {get; set;}
        public DbSet<Reminder> Reminders {get; set;}
        public DbSet<UserLog> UserLog {get; set;}
        public DbSet<Voivodeship> Voivodeships {get; set;}
        public DbSet<Sex> Sexes {get; set;}
        public DbSet<Education> Educations {get; set;}
        public DbSet<AreaOfResidence> AreasOfResidence {get; set;}
        public SzdDbContext(DbContextOptions<SzdDbContext> options) : base(options) {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<TrainingTag>()
                .HasKey(TrainingType => new {
                    TrainingType.TrainingId,
                    TrainingType.TagName
                });
            modelBuilder.Entity<Entry>()
                .HasKey(Entry => new {
                    Entry.TrainingId,
                    Entry.UserPhoneNumber
                });

            modelBuilder.Entity<TrainingLocalization>()
                .HasKey(trainingLocalization => new {
                    trainingLocalization.TrainingId,
                    trainingLocalization.CountyId
                });

            modelBuilder.Entity<TrainingMarketStatus>()
                .HasKey(trainingMarketStatus => new {
                    trainingMarketStatus.TrainingId,
                    trainingMarketStatus.MarketStatusId
                });
            modelBuilder.Entity<MarketStatus>()
                .HasIndex(MarketStatus => MarketStatus.Status).IsUnique();
        }
    }
}