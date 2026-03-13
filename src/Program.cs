
using DotnetWorkshop;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;
using System.Threading.Tasks;

var exampleFactory = new ExampleRunner(new GeneralSettings() {  AppName = "DotnetWorkshop", Version = "1.0.0", Author = "Quirijn" });
exampleFactory.Start();


