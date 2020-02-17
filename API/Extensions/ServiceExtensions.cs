using System;
using System.Diagnostics;
using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using API.Models;
using API.Repository;
using API.Settings;
using API.Types;
using HotChocolate;


namespace API.Extensions
{
    public static class ServiceExtensions
    {
        private static IConfiguration Config { get; } = LoadConfiguration();

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                    );
            });
        }

        public static void ConfigureDatabase(this IServiceCollection services)
        {
            services
                .AddDbContext<CustomDataProfileDBContext>(
                options => options.UseSqlServer(Config.GetConnectionString("DataProfile")
                )
            );

            services
                .AddDbContext<DataProfileDBContext>(
                options => options.UseSqlServer(Config.GetConnectionString("DataProfile")
                )
            );
        }

        public static void ConfigureDataRepository(this IServiceCollection services)
        {
            services.AddTransient<IDataProfileRepository, DataProfileRepository>();
        }

        public static void ConfigureAPISettings(this IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<AppSettings>(Config.GetSection("<Section>"));
        }

        public static void ConfigureGraphQL(this IServiceCollection services)
        {
            services.AddGraphQL(x => SchemaBuilder.New()
                .AddServices(x)
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
                .Create()
            );
        }

        private static IConfiguration LoadConfiguration()
        {
            // * Reference: https://stackoverflow.com/questions/6041332/best-way-to-get-application-folder-path
            
            // determine environment
            //var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // ! this will not work properly when debugging in VS Code
            // var pathToExe = Process.GetCurrentProcess().MainModule.FileName;

            var pathToExe = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var pathToContentRoot = System.IO.Path.GetDirectoryName(pathToExe);
            Directory.SetCurrentDirectory(pathToContentRoot);

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory());

            configuration
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"Settings/appsettings.json", optional: false, reloadOnChange: true);

            return configuration.Build();
        }
    }
}
