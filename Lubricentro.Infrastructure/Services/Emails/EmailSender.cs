using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

namespace Lubricentro.Infrastructure.Services.Emails;

internal class EmailSender : IEmailSender
{
    private readonly GmailSettings _gmailSettings;
    private readonly OutlookSettings _outlookSettings;
    const string GMailAccount = "nicogonzalez42331880@gmail.com";
    const string OutlookAccount = "nico1_a_gonzalez@hotmail.com";
    const string OutlookPassword = "legolas27";

    public EmailSender(IOptions<GmailSettings> gmailSettings, IOptions<OutlookSettings> outlookSettings)
    {
        _gmailSettings = gmailSettings.Value;
        _outlookSettings = outlookSettings.Value;
    }

    public async Task SendGmailAsync(MimeMessage message)
    {
        var clientSecrets = new ClientSecrets
        {
            ClientId = "751464693568-612o9q3piakb863efbnf9kouquh8fu3p.apps.googleusercontent.com",
            ClientSecret = "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"
        };

        var codeFlow = new GoogleAuthorizationCodeFlow(new GoogleAuthorizationCodeFlow.Initializer
        {
            DataStore = new FileDataStore("CredentialCacheFolder", false),
            Scopes = new[] { "https://mail.google.com/" },
            ClientSecrets = clientSecrets
        });

        // Note: For a web app, you'll want to use AuthorizationCodeWebApp instead.
        var codeReceiver = new LocalServerCodeReceiver();
        var authCode = new AuthorizationCodeInstalledApp(codeFlow, codeReceiver);

        var credential = await authCode.AuthorizeAsync(GMailAccount, CancellationToken.None);

        if (credential.Token.IsStale)
            await credential.RefreshTokenAsync(CancellationToken.None);

        var oauth2 = new SaslMechanismOAuth2(credential.UserId, credential.Token.AccessToken);

        using SmtpClient client = new();
        await client.ConnectAsync(_gmailSettings.Smtp, _gmailSettings.Port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(oauth2);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }

    public async Task SendOutlookAsync(MimeMessage message)
    {
        using SmtpClient client = new();
        Console.WriteLine(_outlookSettings.Smtp);
        await client.ConnectAsync(_outlookSettings.Smtp, _outlookSettings.Port, SecureSocketOptions.StartTls);
        await client.AuthenticateAsync(OutlookAccount,OutlookPassword);
        await client.SendAsync(message);
        await client.DisconnectAsync(true);
    }
}
