﻿

using Eclipseworks.Application.DTOs.Email;
using Eclipseworks.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace Eclipseworks.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendAsync(EmailRequestDto request)
        {
            var emailClient = new SmtpClient("localhost");
            var message = new MailMessage
            {
                From = new MailAddress(request.From),
                Subject = request.Subject,
                Body = request.Body
            };
            message.To.Add(new MailAddress(request.To));
            await emailClient.SendMailAsync(message);
        }
    }
}
