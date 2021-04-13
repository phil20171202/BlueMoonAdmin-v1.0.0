using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Services
{
    public class EmailSender : IEmailSender
    {
        private SmtpClient Client { get; }
        private EmailSenderOptions Options { get; }

        public EmailSender(IOptions<EmailSenderOptions> options)
        {
            Options = options.Value;
            Client = new SmtpClient()
            {
                Host = Options.Host,
                Port = Options.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Options.Email, Options.Password),
                EnableSsl = Options.EnableSsl,
            };
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = new MailMessage(from: Options.Email, to: email, subject: subject, body: message);
            mail.IsBodyHtml = true;
            return Client.SendMailAsync(mail);
        }
    }
}