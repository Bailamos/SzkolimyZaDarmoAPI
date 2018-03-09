using System;
using Szkolimy_za_darmo_api.Controllers.Resources.Return;

namespace Szkolimy_za_darmo_api.Controllers.Resources.Response
{
    public class EntryResource
    {
        public DateTime InsertDate{get; set;}
        public TrainingResource Training{get; set;}
    }
}