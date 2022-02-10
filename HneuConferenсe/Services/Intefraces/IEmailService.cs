using System;
using System.Threading.Tasks;

namespace HneuConferenсe.Services.Intefraces
{
    public interface IEmailService
    {
        public Task SendAsync(string recipient, string subject, string messageBody);
    }
}
