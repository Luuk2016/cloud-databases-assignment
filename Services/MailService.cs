using LKenselaar.CloudDatabases.CustomExceptions;
using LKenselaar.CloudDatabases.DAL;
using LKenselaar.CloudDatabases.DAL.Repositories.Interfaces;
using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Services.Interfaces;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LKenselaar.CloudDatabases.Services
{
    public class MailService : IMailService
    {
        private readonly ILogger<MailService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMortgageRepository _mortgageRepository;
        private readonly FunctionConfiguration _config;

        public MailService(ILogger<MailService> logger, IUserRepository userRepository, IMortgageRepository mortgageRepository, FunctionConfiguration config)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mortgageRepository = mortgageRepository ?? throw new ArgumentNullException(nameof(mortgageRepository));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        private async Task SendEmail(User user)
        {
            // Set the email details
            SendGridClient client = new SendGridClient(_config.SendgridAPIKey);
            EmailAddress sender = new EmailAddress("luuk@lkenselaar.dev");
            string subject = "BuyMyHouse - calculated mortgage";
            EmailAddress receiver = new EmailAddress(user.Email);

            string contentPlaintext = $"Beste {user.Name}, klik op de onderstaande link om de gegevens van uw berekende hypotheek te zien. Deze link is 24 uur geldig. http://localhost:7071/api/mortgage/{user.Id}";

            string contentHTML = $"Beste {user.Name}, <br> klik op de onderstaande link om de gegevens van uw berekende hypotheek te zien. Deze link is 24 uur geldig.<br><a href='http://localhost:7071/api/mortgage/{user.Id}'>Klik hier</a>";

            SendGridMessage message = MailHelper.CreateSingleEmail(sender, receiver, subject, contentPlaintext, contentHTML);

            Response response = await client.SendEmailAsync(message);

            if (response.IsSuccessStatusCode)
            {
                user.Mortgage.MailSend = true;
                await _userRepository.Commit();
            }
            else
            {
                _logger.LogError($"Mail couldn't be send");
                throw new CustomException(ErrorCodes.MailNotSend.Key, string.Format(ErrorCodes.MailNotSend.Value));
            }
        }

        public async Task MailAllUsers()
        {
            foreach (User user in await _userRepository.GetAll())
            {
                // Check if the mortgage is set and if the user hasn't already received an email
                if (user.Mortgage != null && user.Mortgage.MailSend == false)
                {
                    await SendEmail(user);
                }   
                else
                {
                    _logger.LogInformation($"UserId: {user.Id} - mortgage not set, or has already been set");
                }
            }
        } 
    }
}
