
namespace LKenselaar.CloudDatabases.API.Models.DTO
{
    public class HouseResponseDTO 
    {
        public Guid HouseId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public double Price { get; set; } 
    }
}