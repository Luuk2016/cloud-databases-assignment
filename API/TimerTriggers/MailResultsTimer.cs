using cloud_databases_assignment.API.Controllers;
using LKenselaar.CloudDatabases.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Timer = LKenselaar.CloudDatabases.Models.Timer;

namespace cloud_databases_assignment.API.TimerTriggers
{
    public class MailResultsTimer
    {
        private readonly ILogger<MailResultsTimer> _logger;
        private readonly UserService _userService;

        public MailResultsTimer(ILogger<MailResultsTimer> logger, UserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [Function("MailResults")]
        public void Run([TimerTrigger("0 0 8 * * *")] Timer timer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
