using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(16)]
        public string PhoneNumber {get; set;}

        [Required]
        public string Name {get; set;}

        [Required]
        public string Surname {get; set;}

        [Required]
        [MaxLength(100)]
        public string Email {get; set;}

        public int Age {get; set;}

        public int LocalizationId {get; set;}

        public Localization Localization {get; set;}

        public int? MarketStatusId {get; set;}

        public MarketStatus MarketStatus {get; set;}

        public ICollection<Entry> Entries {get; set;}

        public ICollection<UserLog> UserLogs {get; set;}

        public User(){
            this.Entries = new Collection<Entry>();
            this.UserLogs = new Collection<UserLog>();
        }

    }
}