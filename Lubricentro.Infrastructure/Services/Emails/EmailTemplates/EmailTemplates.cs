using MimeKit;

namespace Lubricentro.Infrastructure.Services.Emails.EmailTemplates
{
    public static class EmailTemplates
    {
        public static TextPart NewAccount(string password) => new("html") { Text = $"""
<h1> Tu cuenta en lubricentro a sido creada </h1>
<p> Tu nueva contraseña es: {password} </p>
""" };
        public static TextPart PasswordRecovery(string password) => new ("html") { Text = $"""
<h1> Tu contraseña en lubricentro a sido recuperada.</h1>
<p> Tu nueva contraseña es: {password} </p>
""" };
    }
}
