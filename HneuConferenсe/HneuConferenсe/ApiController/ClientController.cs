using System;
using System.Threading.Tasks;
using HneuConferenсe.Services.Intefraces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HneuConferenсe.ApiController
{
    [Route("api/")]
    public class ClientController: Controller
    {
        private readonly IEmailService _emailService;

        public ClientController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send_emails")]
        public async Task<ActionResult> SendEmailNotification([FromBody] ParticipantModel participantModel)
        {
            if (participantModel.Email != null && participantModel.NeededSendEmail)
            {
                await _emailService.SendAsync(participantModel.Email, EmailTypes.SendForParticipant);
                return Ok();
            }
            else
                return BadRequest("Cannot send message: neededSendEmail is false.");
        }
    }
}
