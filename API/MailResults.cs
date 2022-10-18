using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace LKenselaar.CloudDatabases.API
{
    public class MailResults
    {
        private readonly ILogger _logger;

        public MailResults(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MailResults>();
        }

        [Function("MailResults")]
        public void Run([TimerTrigger("0 0 8 * * *")] MailResultsTimer timer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            _logger.LogInformation($"Next timer schedule at: {timer.ScheduleStatus.Next}");
        }
    }

    public class MailResultsTimer
    {
        public MailResultsSchedule ScheduleStatus { get; set; }

        public bool IsPastDue { get; set; }
    }

    public class MailResultsSchedule
    {
        public DateTime Last { get; set; }

        public DateTime Next { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
