using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UserSecretsExample
{
    public static class ServiceProviderBuilder
    {
        public static IServiceProvider GetServiceProvider(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables()
                .AddUserSecrets(typeof(Program).Assembly)
                .AddCommandLine(args)
                .Build();
            var services = new ServiceCollection();

            services.Configure<MyOptions>(configuration.GetSection(typeof(MyOptions).FullName));

            var provider = services.BuildServiceProvider();
            return provider;
        }
    }
}
