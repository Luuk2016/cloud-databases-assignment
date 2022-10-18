using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LKenselaar.CloudDatabases
{
    public class Program
    {
        public static void Main()
        {
            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureServices(services =>
                {
                    services.AddAutoMapper(typeof(Program));
                })
                .Build();

            host.Run();
        }
    }
}



