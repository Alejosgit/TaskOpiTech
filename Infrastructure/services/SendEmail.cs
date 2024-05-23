using SendGrid.Helpers.Mail;
using SendGrid;
using Application.DrivingTask;

namespace Infrastructure.services
{
    public class SendEmail(string apikey): ISendEmail
    {
        private readonly string _apikey= apikey;

        public async Task SendEmailTask(string transmitter, string receiver, string subject, string body, string html)
        {
            SendGridClient client =new  (_apikey);
            EmailAddress  from = new(transmitter);
            EmailAddress  to = new(receiver);
            SendGridMessage msg = MailHelper.CreateSingleEmail(from,to,subject,body,html);
            Response response = await client.SendEmailAsync(msg);
        }
    }
}
