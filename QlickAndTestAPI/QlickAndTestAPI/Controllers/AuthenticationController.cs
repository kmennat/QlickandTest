using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using QlickAndTestApi.BusinessObjects;
using QlickAndTestApi.Interfaces;
using System.Net.Mail;

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

        public class ContactUsRequest
        {
            public string Message { get; set; }
            public string Title { get; set; }
            public string EmailAddress { get; set; }
            public string ?CVFilePath { get; set; }
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
        public async Task<IActionResult> SendMail(ContactUsRequest request)
        {
            SmtpClient smtpClient = new SmtpClient("w01dabd7.kasserver.com", 465);

            smtpClient.Credentials = new System.Net.NetworkCredential("hello@qlickandtest.de", "hello#3112");
            // smtpClient.UseDefaultCredentials = true; // uncomment if you don't want to use the network credentials
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.Subject = request.Title;
            mail.Body = request.Message;
            if (request.CVFilePath != null)
                mail.Attachments.Add(new Attachment(request.CVFilePath));

            //Setting From , To and CC
            mail.From = new MailAddress(request.EmailAddress, "Qlick And Test");
            mail.To.Add(new MailAddress("hello@qlickandtest.de"));

            smtpClient.Send(mail);




            //await _mailkitsenderService.SendEmailAsync(request.EmailAddress, request.Title, request.Message);
            return NoContent();
        }


    }
}
