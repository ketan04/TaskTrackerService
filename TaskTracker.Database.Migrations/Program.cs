using FluentMigrator.Runner;
using FluentMigrator.Runner.Initialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace TaskTracker.Database.Migrations
{

    [ExcludeFromCodeCoverage]
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            var serviceProvider = CreateServices(configuration);

            // Put the database update into a scope to ensure
            // that all resources will be disposed
            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider);
            }
        }

        private static IServiceProvider CreateServices(IConfiguration configuration)
        {
            string? environmentName = configuration["ASPNETCORE_ENVIRONMENT"];
            bool isDevelopment =
                 string.Compare(environmentName, "development", StringComparison.CurrentCultureIgnoreCase) == 0;
            bool isCi = string.Compare(environmentName, "ci", StringComparison.CurrentCultureIgnoreCase) == 0;
            bool useLocalConfig = isDevelopment || isCi;

            string? connectionString = useLocalConfig
               ? configuration["LOCAL_CONNECTIONSTRING"]
               : GetConnectionString(configuration);

            IServiceCollection serviceCollection = new ServiceCollection()
               // Add common FluentMigrator services
               .AddFluentMigratorCore()
               .ConfigureRunner(rb => rb
                   // Add Postres support to FluentMigrator
                   .AddPostgres()
                   .WithVersionTable(new VersionInfo())
                   // Set the connection string
                   .WithGlobalConnectionString(connectionString)
                   // Define the assembly containing the migrations
                   .ScanIn(Assembly.GetExecutingAssembly()).For.All())
               .AddLogging(lb =>
               {
                   lb.AddFluentMigratorConsole();
                   lb.SetMinimumLevel(LogLevel.Trace);
               })
               //--this should wrap ALL migrations ran in a single transaction.
               .Configure<RunnerOptions>(opt =>
               {
                   opt.TransactionPerSession = true;
               });

            return serviceCollection.BuildServiceProvider(false);
        }

        /// <summary>
        ///     Update the database.
        /// </summary>
        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            try
            {
                // Execute the migrations
                runner.MigrateUp();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        /// <summary>
        /// This will be used to build environment specific connection string.
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns></returns>
        private static string GetConnectionString(IConfiguration configuration)
        {
            //nullability is a issue, which should surface on console and force to add required configurations as fix during deployment.
            //in my ideal world this should be env variables mounted on pods through deployment scripts. 
            string? user = configuration["DB_USERNAME"];
            string? password = configuration["DB_PASSWORD"];
            string? host = configuration["PGHOST"];
            string? database = configuration["DB_DATABASE"];
            string? port = configuration["PGHOST_PORT"];

            var connectionString =  new StringBuilder($"Host={host};Port={port};Database={database};User Id={user};Password={password};") ;
          
            return connectionString.ToString();
        }
    }
}