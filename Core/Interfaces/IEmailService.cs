using Szkolimy_za_darmo_api.Controllers.Resources;

namespace Szkolimy_za_darmo_api.Core.Interfaces
{
    public interface IEmailService
    {
        void sendEmail(string to, string subject, string message);

        bool sendEmail(SendMessageResource messageResource);
    }
}