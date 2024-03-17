using MimeKit;

namespace Lubricentro.Infrastructure.Services.Emails;

public interface IEmailSender
{
    Task SendGmailAsync(MimeMessage message);
    Task SendOutlookAsync(MimeMessage message);
}
