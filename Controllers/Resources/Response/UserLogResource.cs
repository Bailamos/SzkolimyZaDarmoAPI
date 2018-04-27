using System;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Response
{
    public class UserLogResource
    {
        public string PropertyName { get; set; }

        public DateTime ChangeDate {get; set;}

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public string ByWho {get; set;}
    }
}