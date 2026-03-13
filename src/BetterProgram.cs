
using DotnetWorkshop;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Threading.Tasks;

var builder = Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) =>
{
    var simpleSetting = hostContext.Configuration["SimpleSetting"]; // not recommended
    var generalSettings = hostContext.Configuration.GetSection(GeneralSettings.SectionName).Get<GeneralSettings>(); // better, for strongly typed
    services.AddSingleton(generalSettings);
    services.AddTransient<ExampleRunner>();
});

builder.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    config.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
});

var host = builder.Build();
var runner = host.Services.GetRequiredService<ExampleRunner>();
runner.Start();
