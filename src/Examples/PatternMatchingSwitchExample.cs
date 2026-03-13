using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetWorkshop.Examples
{
    internal class PatternMatchingSwitchExample : ICodingExample
    {
        public string Name => "Pattern matching";

        public bool IsAsync => false;

        public void Run()
        {
            Console.WriteLine("This example will demonstrate the use of pattern matching in C# 14 to determine the state of water at different temperatures Fahrenheit.\r\n");
            while (true)
            {
                Console.WriteLine($"Please enter a number or 'q' to stop");
                var input = Console.ReadLine();
                if (input?.ToLower() == "q")
                {
                    Console.WriteLine("Back to the main menu");
                    return;
                }
                if (input != null && int.TryParse(input, out int temp))
                {
                    Console.WriteLine($"At {temp} F water is {WaterState(temp)}");
                }
                else
                {
                    Console.Error.WriteLine("Please enter a valid number or 'q' to quit");
                }
            }
        }

        static string WaterState(int tempInFahrenheit) =>
            tempInFahrenheit switch
            {
                < 32 => "solid",
                32 => "solid/liquid transition",
                (> 32) and (< 212) => "liquid",
                212 => "liquid / gas transition",
                > 212 => "gas",
            };


        public Task RunAsync()
        {
            throw new NotImplementedException();
        }
    }
}
