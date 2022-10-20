
using LKenselaar.CloudDatabases.Models.Interfaces;

namespace LKenselaar.CloudDatabases.Models
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string AnnualIncome { get; set; }
        public int LoanTerm { get; set; }
        public double PurchasePrice { get; set; }
        public Mortgage Mortage { get; set; }
    }
}
