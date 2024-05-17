namespace MasterCRM.Infrastructure.Emails;

public record SmtpSettings(string Host, int Port, string Email);