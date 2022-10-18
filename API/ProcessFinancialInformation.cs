using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LKenselaar.CloudDatabases.API
{
    public class ProcessFinancialInformation
    {
        private readonly ILogger _logger;

        public ProcessFinancialInformation(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ProcessFinancialInformation>();
        }

        [Function("ProcessFinancialInformation")]
        public void Run([TimerTrigger("0 30 23 * * *")] ProcessDataTimer myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
        }
    }

    public class ProcessDataTimer
    {
        public ProcessDataSchedule ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class ProcessDataSchedule
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
