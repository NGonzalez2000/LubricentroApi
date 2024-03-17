using Lubricentro.Application.Common.Interfaces.Services;
using MimeKit;

namespace Lubricentro.Infrastructure.Services.Emails;

public class EmailService(IEmailSender emailSender) : IEmailService
{
    private readonly IEmailSender _emailSender = emailSender;
    public async Task SendAsync(string from, string to, string subject, TextPart text)
    {

        MimeMessage mimeMessage = new();
        mimeMessage.From.Add(new MailboxAddress("", from));
        mimeMessage.To.Add(new MailboxAddress("", to));
        mimeMessage.Subject = subject;
        mimeMessage.Body = text;
        if (from.EndsWith("gmail.com"))
        {
            await _emailSender.SendGmailAsync(mimeMessage);
            return;
        }

        if(from.EndsWith("hotmail.com") || from.EndsWith("outlook.com"))
        {
            await _emailSender.SendOutlookAsync(mimeMessage);
        }
    }
}
