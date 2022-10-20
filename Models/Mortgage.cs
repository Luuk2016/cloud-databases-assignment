
namespace LKenselaar.CloudDatabases.Models
{
    public class Mortgage : Entity
    {
        public double MaximumMortage { get; set; }
        public User User { get; set; }
    }
}
