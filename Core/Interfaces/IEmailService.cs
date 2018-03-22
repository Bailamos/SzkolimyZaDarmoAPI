namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface IEmailService
    {
        void sendEmail(string to, string subject, string message);
    }
}