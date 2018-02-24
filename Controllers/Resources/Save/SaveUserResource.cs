namespace Szkolimy_za_darmo_api.Controllers.Resources.Save
{
    public class SaveUserResource
    {
        public string PhoneNumber {get; set;}
        public string Name {get; set;}
        public string Surname {get; set;}
        public SaveEntryResource Entry {get; set;}
    }
}