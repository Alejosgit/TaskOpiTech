

using Application.DrivingTask;

namespace Application.SendTaskEmail
{
    public class EmailSend(ISendEmail emailTask) : IEmailSend
    {
        private readonly ISendEmail _emailTask = emailTask;

        public  async Task TaskEmailSend(string emailReceiver, string bodyMessage)
        {
            await _emailTask.SendEmailTask("alejandro.hurtadob@opitech.com.co", emailReceiver,"Correo prueba", bodyMessage,null);
        }
    }
}
