using HneuConferenсe;
using HneuConferenсe.Services.Intefraces;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Frame.Server.Services.Implementations
{
    public class MailKitEmailService : IEmailService
    {
        private const string EMAIL_CREDENTIALS_JSON_SECTION = "KhneuEmailCredentials";
        private const string SERVER_HOST = "smtp.gmail.com";
        private const int SERVER_PORT = 465;

        private readonly IConfiguration config;

        public MailKitEmailService(IConfiguration configuration)
        {
            config = configuration;
        }

        public async Task SendAsync(string recipient, string subject, string messageBody)
        {
            string senderEmail = config.GetSection(EMAIL_CREDENTIALS_JSON_SECTION)["Email"];
            string senderName = config.GetSection(EMAIL_CREDENTIALS_JSON_SECTION)["Name"];
            string senderPassword = config.GetSection(EMAIL_CREDENTIALS_JSON_SECTION)["Password"];

            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress(senderName,senderEmail);
            MailboxAddress to = MailboxAddress.Parse(recipient);
           
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = messageBody
            };

            using SmtpClient client = new SmtpClient();

            try
            {
                await client.ConnectAsync(SERVER_HOST, SERVER_PORT, true);
                await client.AuthenticateAsync(senderEmail, senderPassword);
                await client.SendAsync(message);
            }
            finally 
            {
                await client.DisconnectAsync(true);
            }
        }
    }
}
