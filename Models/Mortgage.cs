
namespace LKenselaar.CloudDatabases.Models
{
    public class Mortgage : Entity
    {
        public double? MaximumMortgage { get; set; }
        public Guid UserId { get; set; }
        public bool MailSend { get; set; }
    }
}
