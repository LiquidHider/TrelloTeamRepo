using System.Threading.Tasks;
using HneuConferenсe.Services.Intefraces;
using HneuConferenсe.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HneuConferenсe.ApiController
{
    [Route("api/")]
    public class ClientController: Controller
    {
        private const string EMAIL_CREDENTIALS_JSON_SECTION = "KhneuEmailCredentials";
        private const string PARTICIPANT_MESSAGE_PATTERN_PATH = "MessagePatterns/ParticipantMessage.html";
        private const string LEAD_MESSAGE_PATTERN_PATH = "MessagePatterns/LeadMessage.html";

        private readonly IEmailService emailService;
        private readonly IDataInserter dataInserter;
        private readonly IConfiguration config;

        public ClientController(IConfiguration configuration, IEmailService emailService, IDataInserter dataInserter)
        {
            this.emailService = emailService;
            this.dataInserter = dataInserter;
            config = configuration;
        }

        [HttpPost("send_emails")]
        public async Task<ActionResult> SendEmailNotification([FromBody] ParticipantModel participantModel)
        {
            if (participantModel.Email != null)
            {
                if (participantModel.NeededSendEmail)
                {
                    string participantMessage = System.IO.File.ReadAllTextAsync(PARTICIPANT_MESSAGE_PATTERN_PATH).Result;

                    participantMessage = dataInserter.InsertData(participantMessage, participantModel);

                    await emailService.SendAsync(participantModel.Email, "Успішна реєстрація на конференцію ХНЕУ!", participantMessage);
                }

                string leadMessage = System.IO.File.ReadAllTextAsync(LEAD_MESSAGE_PATTERN_PATH).Result;

                leadMessage = dataInserter.InsertData(leadMessage, participantModel);

                await emailService.SendAsync(config.GetSection(EMAIL_CREDENTIALS_JSON_SECTION)["Email"], $"Компанія {participantModel.CompanyName} була зареєстрована на конференцію.", leadMessage);

                return Ok();
            }
            else
            {
                return BadRequest("Cannot send message: neededSendEmail is false.");
            }


        }
    }
}
