using System.ComponentModel.DataAnnotations.Schema;

namespace Szkolimy_za_darmo_api.Core.Models
{
    [Table("instructor_roles")]
    public class InstructorRole
    {
        public int RoleId {get; set;}
        public int InstructorId{get; set;}
        public Instructor Instructor {get; set;}
        public Role role {get; set;}
    }
}