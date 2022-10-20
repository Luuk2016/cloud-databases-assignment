using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;

namespace LKenselaar.CloudDatabases.Models.DTO
{
    public class CreateUserRequestDTO
    {
        [JsonRequired]
        [OpenApiProperty(Default = "John", Description = "The name of the user")]
        public string Name { get; set; }

        [JsonRequired]
        [OpenApiProperty(Default = "johndoe@email.com", Description = "The email of the user")]
        public string Email { get; set; }

        [JsonRequired]
        [OpenApiProperty(Default = "50000", Description = "The annual income of the user")]
        public double AnnualIncome { get; set; }

        [JsonRequired]
        [OpenApiProperty(Default = "240", Description = "The loan term in months")]
        public int LoanTerm { get; set; }
    }
}
