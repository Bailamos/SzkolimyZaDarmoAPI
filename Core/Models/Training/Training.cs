using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("trainings")]
    public class Training
    {
        public int Id {get; set;}

        [Required]
        [MaxLengthAttribute(255)]
        public string Title {get; set;}

        [Required]
        [MaxLengthAttribute(2000)]
        public string Description {get; set;}

        public DateTime LastUpdate {get; set;}

        public DateTime InsertDate {get; set;}

        public DateTime RegisterSince {get; set;}

        public DateTime RegisterTo {get; set;}

        [Required]
        public string CategoryName { get; set; } 

        [Required]
        [MaxLength(255)]
        public string ContactEmail {get; set;}

        [Required]
        [MaxLength(255)]
        public string ContactPhoneNumber {get; set;}

        public Category Category {get; set;}

        public int MarketStatusId{get; set;}

        public MarketStatus MarketStatus {get; set;}

        public int LocalizationId {get; set;}

        public Localization Localization {get; set;}

        public int VoivodeshipId {get; set;}

        public Voivodeship Voivodeship {get; set;}

        public int InstructorId {get; set;}

        public Instructor Instructor {get; set;}

        public ICollection<Entry> Entries {get; set;}

        public ICollection<TrainingTag> Tags {get; set;}

        public ICollection<TrainingLocalization> Counties {get; set;}
        
        public ICollection<TrainingMarketStatus> MarketStatuses {get; set;}

        public Training() {
            this.Tags = new Collection<TrainingTag>();
            this.Entries = new Collection<Entry>();
            this.Counties = new Collection<TrainingLocalization>();
            this.MarketStatuses = new Collection<TrainingMarketStatus>();
        }
    }
}