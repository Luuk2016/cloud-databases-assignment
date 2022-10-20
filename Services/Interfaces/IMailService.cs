using LKenselaar.CloudDatabases.Models;
using SendGrid;

namespace cloud_databases_assignment.Services.Interfaces
{
    public interface IMailService
    {
        public Task SendEmail(User user);
        public Task MailAllUsers();
    }
}
