using GaleriaDavinci.Web.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GaleriaDavinci.Web.Services
{
    public class SendgridService : IEmailService
    {
        private readonly ISendGridClient _sendgridClient;

        public SendgridService(ISendGridClient sendgridClient)
        {
            _sendgridClient = sendgridClient;
        }

        public async Task SendEmail(string to, string subject, string content)
        {
            var email = new SendGridMessage
            {
                From = new EmailAddress("jose.escudero@udla.edu.ec"),
                Subject = subject,
                Contents = new List<Content>
                {
                    new Content(MimeType.Html, content)
                }
            };
            email.AddTo(to);
            var response = await _sendgridClient.SendEmailAsync(email);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to send email");
            }

            var result = await response.Body.ReadAsStringAsync();
            int x = 4;
        }
    }
}
