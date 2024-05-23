namespace Application.SendTaskEmail
{
    public interface IEmailSend
    {
        Task TaskEmailSend(string emailReceiver, string bodyMessage);
    }
}
