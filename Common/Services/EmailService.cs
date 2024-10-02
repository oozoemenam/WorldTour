using System.Net.Mail;
using Microsoft.Extensions.Options;
using MimeKit;
using WorldTour.Common.Exceptions;
using WorldTour.Common.Interfaces;
using WorldTour.Common.Settings;
using WorldTour.Dtos;

namespace WorldTour.Common.Services;

public class EmailService : IEmailService
{
    private MailSettings MailSettings { get; }
    private ILogger<EmailService> Logger { get; }

    public EmailService(IOptions<MailSettings> mailSettings, ILogger<EmailService> logger)
    {
        MailSettings = mailSettings.Value;
        Logger = logger;
    }

    public async Task SendAsync(EmailDto request)
    {
        try
        {
            // var email = new MimeMessage { Sender = MailboxAddress.Parse(request.From ?? MailSettings.EmailFrom) };
            // var email = new MailMessage { Sender = MailAddress.TryCreate(request.From ?? MailSettings.EmailFrom, out MailSettings.EmailFrom) };
            MailAddress address = new MailAddress(request.From ?? MailSettings.EmailFrom!);
            var email = new MailMessage { Sender = address };
            email.To.Add(request.To!);
            email.Subject = request.Subject;
            var builder = new BodyBuilder { HtmlBody = request.Body };
            email.Body = builder.TextBody;

            using var smtp = new SmtpClient();
            await smtp.SendMailAsync(email);
             smtp.Dispose();
        }
        catch (System.Exception ex)
        {
            Logger.LogError(ex.Message, ex);
            throw new ApiException(ex.Message);
        }
    }
}