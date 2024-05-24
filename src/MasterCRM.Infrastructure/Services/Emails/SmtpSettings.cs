namespace MasterCRM.Infrastructure.Services.Emails;

public record SmtpSettings(string Host, int Port, string Email);