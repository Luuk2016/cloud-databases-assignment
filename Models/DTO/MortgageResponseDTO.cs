
namespace LKenselaar.CloudDatabases.Models.DTO
{
    public class MortgageResponseDTO
    {
        public Guid Id { get; set; }
        public double MaximumMortgage { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
