using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Szkolimy_za_darmo_api.Controllers.Resources;
using Szkolimy_za_darmo_api.Core.Interfaces;

namespace Szkolimy_za_darmo_api.Controllers
{
    [Route("/api/message")]
    public class MessagingController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        public MessagingController(IMapper mapper, IEmailService emailService)
        {
            this.emailService = emailService;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult sendEmail([FromBody] SendMessageResource messageResource)
        {
            bool result = emailService.sendEmail(messageResource);
            if (result)
                return Ok();
            else
                return BadRequest();
        }
    }
}