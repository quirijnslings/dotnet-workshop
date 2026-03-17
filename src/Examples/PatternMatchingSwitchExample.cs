using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetWorkshop.Examples;

internal class PatternMatchingSwitchExample : ICodingExample
{
    public string Name => "Pattern matching";

    public bool IsAsync => false;

    public void Run()
    {
        object o = 42;
        if (o is int)
        {
            Console.WriteLine($"o is an int");
        }
        if (o is int i)
        {
            Console.WriteLine($"o is an int and its value is {i}");
        }
        if (o is { })
        {
            Console.WriteLine($"o is not null");
        }
        if (o is not null)
        {
            Console.WriteLine($"o is not null");
        }
        if (o is null)
        {
            Console.WriteLine($"wait, that's strange: o is null");
        }

        Console.WriteLine("This example will demonstrate the use of pattern matching in a C# 14 switch expression to determine the state of water at different temperatures Fahrenheit.\r\n");
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
            < 32 => "solid",   // relational pattern (<, >, <=, >=)
            32 => "solid/liquid transition", 
            (> 32) and (< 212) => "liquid", // relation pattern in combination with logical pattern (and, or, not)
            212 => "liquid / gas transition",
            // > 212 => "gas", 
            _ => "gas", // instead of listing all possibilities, you can also use the discard pattern
        };


    public Task RunAsync()
    {
        throw new NotImplementedException();
    }
}


