using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using QlickAndTestApi.BusinessObjects;
using QlickAndTestApi.Interfaces;

namespace QlickAndTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IEmailSender _mailkitsenderService;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService, IEmailSender mailkitsenderService)
        {
            _mailkitsenderService = mailkitsenderService;
            _authenticationService = authenticationService;
        }

        public class ApplyJobRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Vorname { get; set; }
            public string Email { get; set; }
            public string Tel { get; set; }
            public string Address { get; set; }
            public string CVFilePath { get; set; }
        }


        [HttpPost]
        [Route("token")]
        public ActionResult<LoginResponse> Login(LoginRequest request)
        {
            return _authenticationService.Login(request);
        }

        [HttpPost]
        [Route("apply")]
        public async Task<ActionResult<Identity>> ApplyForJob(ApplyJobRequest user)
        {
            return await _authenticationService.AddNewUser(user);
        }

        [HttpPost]
        [Route("contact")]
        public async Task<IActionResult> SendMail(string email, string subject, string message)
        {
            await _mailkitsenderService.SendEmailAsync(email, subject, message);
            return NoContent();
        }


    }
}
