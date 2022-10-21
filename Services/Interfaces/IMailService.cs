using LKenselaar.CloudDatabases.Models;

namespace LKenselaar.CloudDatabases.Services.Interfaces
{
    public interface IMailService
    {
        public Task SendEmail(User user);
        public Task MailAllUsers();
    }
}
