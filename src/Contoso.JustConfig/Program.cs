using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using Contoso.Shared;

namespace Contoso.JustConfig
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            var options = new ContosoOptions {
                Name = configuration.GetValue<string>("Contoso:Name"),
                Order = configuration.GetValue<int>("Contoso:Order"),
                Active = configuration.GetValue<bool>("Contoso:Active")
            };

            Console.WriteLine("Options WITHOUT bind");
            Console.WriteLine(options);

            options = configuration.GetSection("Contoso").Get<ContosoOptions>();

            Console.WriteLine("Options WITH bind");
            Console.WriteLine(options);
        }
    }
}
