// using SendGrid's C# Library
// https://github.com/sendgrid/sendgrid-csharp
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Application.DrivingTask
{
    public interface ISendEmail
    {
        Task SendEmailTask(string transmitter, string receiver, string subject, string body, string html);
    }
}
