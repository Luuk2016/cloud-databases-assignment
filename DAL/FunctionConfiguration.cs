using Microsoft.Extensions.Configuration;

namespace LKenselaar.CloudDatabases.DAL
{
    public class FunctionConfiguration
    {
        public string CosmosAccountEndpoint { get; }
        public string CosmosAccountKey { get; }
        public string CosmosDatabaseName { get; }
        public string SendgridAPIKey { get; }

        public FunctionConfiguration(IConfiguration config)
        {
            CosmosAccountEndpoint = config["CosmosAccountEndpoint"];
            CosmosAccountKey = config["CosmosAccountKey"];
            CosmosDatabaseName = config["CosmosDatabaseName"];
            SendgridAPIKey = config["SendgridAPIKey"];
        }
    }
}
