
namespace LKenselaar.CloudDatabases.Models
{
    public class Mortgage : Entity
    {
        public double MaximumMortage { get; set; }
        public Guid UserId { get; set; }
    }
}
