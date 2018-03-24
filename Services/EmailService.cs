using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mail;
using Szkolimy_za_darmo_api.Controllers.Resources;
using Szkolimy_za_darmo_api.Core.Interfaces;

namespace Szkolimy_za_darmo_api.Services
{
    public class EmailService : IEmailService
    {
        public void sendEmail(string to, string subject, string message)
        {
            SmtpClient client = configureClient();
            
            MailMessage mail = new MailMessage("szkolimyzadarmotest@gmail.com", to);
            mail.Subject = subject;
            mail.Body = message;
            client.Send(mail);
        }

        public bool sendEmail(SendMessageResource messageResource)
        {
            SmtpClient client = configureClient();
            MailMessage mail = new MailMessage("szkolimyzadarmotest@gmail.com", messageResource.Receivers[0]);
            messageResource.Receivers.ToList().ForEach(rec => mail.To.Add(rec));
            mail.Subject = messageResource.Subject;
            mail.Body = messageResource.Message;
            
            try {
                client.SendAsync(mail, null);
                return true;
            } catch (ObjectDisposedException) {
                return false;
            }
        }

        private SmtpClient configureClient() {
             SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.gmail.com";
            client.Credentials = new System.Net.NetworkCredential("szkolimyzadarmotest@gmail.com", "admin1234qwer");
            return client;
        }
    }
}