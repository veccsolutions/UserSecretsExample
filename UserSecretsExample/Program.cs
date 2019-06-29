using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace UserSecretsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = ServiceProviderBuilder.GetServiceProvider(args);
            var options = services.GetRequiredService<IOptions<MyOptions>>();

            Console.WriteLine("OpenOption:   " + options.Value.OpenOption);
            Console.WriteLine("SecretOption: " + options.Value.SecretOption);
        }
    }
}
