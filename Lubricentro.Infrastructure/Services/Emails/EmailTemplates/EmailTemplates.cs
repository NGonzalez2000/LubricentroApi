using MimeKit;

namespace Lubricentro.Infrastructure.Services.Emails.EmailTemplates
{
    public static class EmailTemplates
    {
        public static TextPart NewAccount(string password) => new ("html") { Text = $"""
<h1> Tu cuentra en lubricentro a sido creada </h1>
<p> Tu nueva contraseña es: {password} </p>
""" };
    }
}
