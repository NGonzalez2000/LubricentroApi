using MimeKit;

namespace Lubricentro.Application.Common.Interfaces.Services;

public interface IEmailService
{
    Task SendAsync(string from, string to, string subject, TextPart text);
}
