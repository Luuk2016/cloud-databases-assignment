using LKenselaar.CloudDatabases.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Timer = LKenselaar.CloudDatabases.Models.Timer;

namespace LKenselaar.CloudDatabases.API.TimerTriggers
{
    public class MailResultsTimer
    {
        private readonly ILogger<MailResultsTimer> _logger;
        private readonly IMailService _mailService;

        public MailResultsTimer(ILogger<MailResultsTimer> log, IMailService mailService)
        {
            _logger = log ?? throw new ArgumentNullException(nameof(log));
            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService));
        }

        [Function("MailResults")]
        public void Run([TimerTrigger("0 26 14 * * *")] Timer timer)
        {
            _logger.LogInformation("Mailing results...");
            _mailService.MailAllUsers();
        }
    }
}
