
namespace LKenselaar.CloudDatabases.Models.DTO
{
    public class CreateUserResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double AnnualIncome { get; set; }
        public int LoanTerm { get; set; }
    }
}
