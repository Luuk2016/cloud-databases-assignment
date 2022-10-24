
namespace LKenselaar.CloudDatabases.Models
{
    public class Mortgage : Entity
    {
        /// <summary>
        /// The maximum mortgage
        /// </summary>
        public double MaximumMortgage { get; set; }

        /// <summary>
        /// The moment the mortgage offer expires
        /// </summary>
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// If the mortgage email has already been send
        /// </summary>
        public bool MailSend { get; set; }
    }
}
