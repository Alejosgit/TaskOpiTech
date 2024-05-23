using Application.Interface;

namespace Application.DrivingTask.Services
{
    
    internal class NotificateSend: INotificateSend
    {
        private readonly IRepository _repository;
        private readonly ISendEmail sendEmail;
        public async Task Notificate() 
        {
            
        }
    }
}
