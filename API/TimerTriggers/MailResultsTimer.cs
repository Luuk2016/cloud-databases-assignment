using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace cloud_databases_assignment.API.TimerTriggers
{
    public class MailResultsTimer
    {
        private readonly ILogger _logger;

        public MailResultsTimer(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MailResultsTimer>();
        }

        [Function("MailResults")]
        public void Run([TimerTrigger("0 0 8 * * *")] Timer timer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
