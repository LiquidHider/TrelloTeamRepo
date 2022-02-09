using HneuConferenсe;
using HneuConferenсe.Services.Intefraces;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Frame.Server.Services.Implementations
{
    public class SendGridEmailService : IEmailService
    {
        private readonly SendGridAccountDetails _sendGridCredentials;
        private readonly EmailCredentials _emailCredentials;
        public SendGridEmailService(IOptions<SendGridAccountDetails> sendGridCredentials,
            IOptions<EmailCredentials> emailCredentials)
        {
            _emailCredentials = emailCredentials.Value ?? throw new ArgumentException();

            _sendGridCredentials = sendGridCredentials.Value ?? throw new ArgumentException();
        }

        public async Task SendAsync(string recipient, EmailTypes emailType)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("hneuconference@gmail.com", "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(recipient, "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>антон залупа конская</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }

        private string TemplateId(EmailTypes emailType)
        {
            switch (emailType)
            {
                case EmailTypes.SendForLead:
                    return "d-69d33c4c86314091b05ef83c1d0bce2f";
                case EmailTypes.SendForParticipant:
                    return "d-d6d99138070d4926856843f0d3c1bcb8";
                default:
                    return null;
            }
        }


    }
}
