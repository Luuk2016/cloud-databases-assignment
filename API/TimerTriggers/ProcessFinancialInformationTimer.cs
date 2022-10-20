using LKenselaar.CloudDatabases.Services;
using LKenselaar.CloudDatabases.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace cloud_databases_assignment.API.TimerTriggers
{
    public class ProcessFinancialInformationTimer
    {
        private readonly ILogger<MailResultsTimer> _logger;
        private readonly UserService _userService;

        public ProcessFinancialInformationTimer(ILogger<MailResultsTimer> logger, UserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [Function("ProcessFinancialInformation")]
        public void Run([TimerTrigger("0 30 23 * * *")] Timer timer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
