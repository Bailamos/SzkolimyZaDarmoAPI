using System;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Response
{
    public class CommentResource
    {
        public string Description {get; set;}

        public DateTime Date{get; set;}

        public string InstructorEmail {get; set;}
    }
}