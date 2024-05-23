using Application.SendTaskEmail;
using Domain.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Application.DrivingTask.Services
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEmailSend _emailSend;

        public Worker(ILogger<Worker> logger, IEmailSend emailSend)
        {
            _logger = logger;
            _emailSend = emailSend;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _emailSend.TaskEmailSend("alejandro.hurtadob@opitech.com.co", "Hola que mas pues");
                }
                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
