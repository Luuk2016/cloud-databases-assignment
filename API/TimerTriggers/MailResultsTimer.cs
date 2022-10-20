using cloud_databases_assignment.Services.Interfaces;
using LKenselaar.CloudDatabases.API.Controllers;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Timer = LKenselaar.CloudDatabases.Models.Timer;

namespace LKenselaar.CloudDatabases.API.TimerTriggers
{
    public class MailResultsTimer
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMailService _mailService;

        public MailResultsTimer(ILogger<UserController> log, IMailService mailService)
        {
            _logger = log ?? throw new ArgumentNullException(nameof(log));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        [Function("MailResults")]
        public void Run([TimerTrigger("0 0 8 * * *")] Timer timer)
        {
            _mailService.MailAllUsers();
        }
    }
}
