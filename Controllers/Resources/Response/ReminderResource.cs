using System;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Response
{
    public class ReminderResource
    {
        public int Id {get; set;}
        public int InstructorId{get; set;}
        public string Description {get; set;}
        public DateTime DueDate {get; set;}
    }
}