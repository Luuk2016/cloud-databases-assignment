using LKenselaar.CloudDatabases.DAL.Repositories;
using LKenselaar.CloudDatabases.DAL;
using Microsoft.Azure.Functions.Worker.Extensions.OpenApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using LKenselaar.CloudDatabases.DAL.Context;
using LKenselaar.CloudDatabases.DAL.Repositories.Interfaces;
using LKenselaar.CloudDatabases.Models;
using LKenselaar.CloudDatabases.Services.Interfaces;
using LKenselaar.CloudDatabases.Services;

namespace LKenselaar.CloudDatabases
{
    public class Program
    {
        public static void Main()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", true, true)
                .AddUserSecrets(Assembly.GetExecutingAssembly(), true)
                .AddEnvironmentVariables()
                .Build();

            var host = new HostBuilder()
                .ConfigureFunctionsWorkerDefaults()
                .ConfigureOpenApi()
                .ConfigureServices(services =>
                {
                    services.AddAutoMapper(typeof(Program));

                    services.AddSingleton(new FunctionConfiguration(config));
                    services.AddDbContext<DatabaseContext>();

                    services.AddScoped<IBaseRepository<User>, UserRepository>();
                    services.AddScoped<IUserService, UserService>();

                    services.AddScoped<IBaseRepository<Mortgage>, MortgageRepository>();
                    services.AddScoped<IMortgageService, MortgageService>();

                    services.AddScoped<IMailService, MailService>();

                    services.AddAutoMapper(typeof(Program));
                })
                .Build();

            host.Run();
        }
    }
}



