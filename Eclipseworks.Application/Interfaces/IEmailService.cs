using Eclipseworks.Application.DTOs.Email;

namespace Eclipseworks.Application.Interfaces
{ 
    public interface IEmailService
    {
        Task SendAsync(EmailRequestDto request);
    }
}
