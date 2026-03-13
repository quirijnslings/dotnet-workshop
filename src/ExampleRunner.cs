using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetWorkshop
{
    public class ExampleRunner (GeneralSettings generalSettings)
    {
        public void Start()
        {
             var exampleTypes = this.GetType().Assembly.GetTypes().Where(type => typeof(ICodingExample).IsAssignableFrom(type) && !type.IsAbstract);

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome to {generalSettings.AppName}, version {generalSettings.Version}. The author ({generalSettings.Author}) hopes you will enjoy it.");

                var i = 1;

                var examples = exampleTypes.Select(type => (ICodingExample)Activator.CreateInstance(type)).OrderBy(example => example.Name);
                foreach (var example in examples)
                {
                    Console.WriteLine($"{i++}) {example.Name}");
                }

                Console.WriteLine();
                Console.WriteLine("Type number to execute or q to quit");
                var input = Console.ReadLine();
                if (input?.ToLower() == "q")
                {
                    Console.WriteLine("Bye now!");
                    return;
                }
                if (int.TryParse(input, out int nr) && nr > 0 && nr <= exampleTypes.Count())
                {
                    var example = examples.ElementAt(nr - 1);
                    RunExample(example);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
        public void RunExample(ICodingExample example)
        {
            if (example.IsAsync)
            {
                example.RunAsync().GetAwaiter().GetResult();
            }
            else
            {
                example.Run();
            }
        }

    }
}
