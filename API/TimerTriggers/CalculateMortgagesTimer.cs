using LKenselaar.CloudDatabases.Services.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Timer = LKenselaar.CloudDatabases.Models.Timer;

namespace LKenselaar.CloudDatabases.API.TimerTriggers
{
    public class CalculateMortgagesTimer
    {
        private readonly ILogger<CalculateMortgagesTimer> _logger;
        private readonly IUserService _userService;

        public CalculateMortgagesTimer(ILogger<CalculateMortgagesTimer> logger, IUserService userService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [Function("CalculateMortgagesTimer")]
        public async Task Run([TimerTrigger("0 30 23 * * *")] Timer timer)
        {
            _logger.LogInformation("Updating mortgages");
            await _userService.CalculateMortgages();
        }
    }
}
