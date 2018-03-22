using System.Net.Mail;
using Szkolimy_za_darmo_api.Core.Interfaces;

namespace Szkolimy_za_darmo_api.Services
{
    public class EmailService : IEmailService
    {
        public void sendEmail(string to, string subject, string message)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Credentials = new System.Net.NetworkCredential("szkolimyzadarmotest@gmail.com", "hejsokoly69");
            
            MailMessage mail = new MailMessage("szkolimyzadarmotest@gmail.com", to);
            mail.Subject = subject;
            mail.Body = message;
            client.Send(mail);
        }
    }
}