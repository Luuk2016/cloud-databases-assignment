using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace cloud_databases_assignment.API.TimerTriggers
{
    public class ProcessFinancialInformationTimer
    {
        private readonly ILogger _logger;

        public ProcessFinancialInformationTimer(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ProcessFinancialInformationTimer>();
        }

        [Function("ProcessFinancialInformation")]
        public void Run([TimerTrigger("0 30 23 * * *")] Timer myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
