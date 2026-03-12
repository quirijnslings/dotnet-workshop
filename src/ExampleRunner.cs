using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetWorkshop
{
    public class ExampleRunner
    {
        public void Start()
        {
            var exampleTypes = this.GetType().Assembly.GetTypes().Where(type => typeof(ICodingExample).IsAssignableFrom(type) && !type.IsAbstract);

            while (true)
            {
                Console.Clear();
                var i = 1;
                foreach (var exampleType in exampleTypes)
                {
                    var example = (ICodingExample)Activator.CreateInstance(exampleType);
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
                    var exampleType = exampleTypes.ElementAt(nr - 1);
                    var example = (ICodingExample)Activator.CreateInstance(exampleType);
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
