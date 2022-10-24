using LKenselaar.CloudDatabases.DAL;
using LKenselaar.CloudDatabases.DAL.Repositories.Interfaces;
using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Services.Interfaces;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace LKenselaar.CloudDatabases.Services
{
    public class MailService : IMailService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMortgageRepository _mortgageRepository;
        private readonly FunctionConfiguration _config;

        public MailService(IUserRepository userRepository, IMortgageRepository mortgageRepository, FunctionConfiguration config)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mortgageRepository = mortgageRepository ?? throw new ArgumentNullException(nameof(mortgageRepository));
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }

        public async Task SendEmail(User user)
        {
            Mortgage mortgage = await _mortgageRepository.GetMortgageByUserId(user.Id);

            // Set the email details
            SendGridClient client = new SendGridClient(_config.SendgridAPIKey);
            EmailAddress sender = new EmailAddress("luuk@lkenselaar.dev");
            string subject = "BuyMyHouse - calculated mortgage";
            EmailAddress receiver = new EmailAddress(user.Email);

            string contentPlaintext = $"Beste {user.Name}, klik op de onderstaande link om de gegevens van uw berekende hypotheek te zien. Deze link is 24 uur geldig. http://localhost:7071/api/mortgage?mortgageId={mortgage.Id}";

            string contentHTML = $"Beste {user.Name}, <br> klik op de onderstaande link om de gegevens van uw berekende hypotheek te zien. Deze link is 24 uur geldig.<br><a href='http://localhost:7071/api/mortgage?mortgageId={mortgage.Id}'>Klik hier</a>";

            SendGridMessage message = MailHelper.CreateSingleEmail(sender, receiver, subject, contentPlaintext, contentHTML);

            Response response = await client.SendEmailAsync(message);

            if (response.IsSuccessStatusCode)
            {
                user.Mortgage.MailSend = true;
                await _userRepository.Commit();
            }
        }

        public async Task MailAllUsers()
        {
            ICollection<User> users = await _userRepository.GetAll();

            foreach (User user in users.ToList())
            {
                // Check if the mortgage is set and if the user hasn't already received an email
                if (user.Mortgage != null && user.Mortgage.MailSend == false)
                {
                    await SendEmail(user);
                }   
            }
        } 
    }
}
