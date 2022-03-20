
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureLogging(builder =>
    {
        builder.AddConsole();
    })
    .Build();
var loggerFactory = host.Services.GetRequiredService<ILoggerFactory>();
var logger = loggerFactory.CreateLogger<Program>();
logger.BeginScope("Logging scope");

if (!args.Any() || !args.Contains("help"))
{
    Console.WriteLine("Usage: SeedLoader --input ../Synthea/output/fhir --server http://localhost:8080");
    return;
}
if (!args.Contains("input"))
{
    throw new ArgumentException("Missing argument --input");
}
if (!args.Contains("server"))
{
    throw new ArgumentException("Missing argument --server");
}
