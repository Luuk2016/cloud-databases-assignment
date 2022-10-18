
namespace LKenselaar.CloudDatabases.API.Models
{
    public class House 
    {
        public Guid HouseId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public double Price { get; set; }
    }
}
