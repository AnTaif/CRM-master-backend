using MailKit.Net.Smtp;
using MasterCRM.Domain.Interfaces;
using MimeKit;

namespace MasterCRM.Infrastructure.Emails;

public class EmailSender : IEmailSender, IDisposable
{
    private readonly SmtpClient smtpClient;
    private readonly string senderEmail;

    public EmailSender(SmtpSettings settings, string username, string password)
    {
        smtpClient = new SmtpClient();
        smtpClient.Connect(settings.Host, settings.Port, useSsl: false);
        smtpClient.Authenticate(username, password);

        senderEmail = settings.Email;
    }
    
    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var message = new MimeMessage();
        
        message.From.Add(new MailboxAddress("МастерскаЯ", senderEmail));
        message.To.Add(new MailboxAddress("", email));
        message.Subject = subject;
        message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
        {
            Text = htmlMessage
        };

        await smtpClient.SendAsync(message);
    }

    public void Dispose()
    {
        smtpClient.Disconnect(true);
        smtpClient.Dispose();
    }
}