
namespace LKenselaar.CloudDatabases.Models
{
    public class User : Entity
    {
        /// <summary>
        /// The name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The annual income of the user
        /// </summary>
        public double AnnualIncome { get; set; }

        /// <summary>
        /// The loan term (in months)
        /// </summary>
        public int LoanTerm { get; set; }

        /// <summary>
        /// The mortgage of the user
        /// </summary>
        public Mortgage Mortgage { get; set; }
    }
}
