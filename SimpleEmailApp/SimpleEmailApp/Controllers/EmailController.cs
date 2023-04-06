﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace SimpleEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("aron45@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("aron45@ethereal.email"));
            email.Subject = "testEmail Subject";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) {Text =body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("aron45@ethereal.email", "Pvk23jACP8hHzQdzMS");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();

        }
    }
}
