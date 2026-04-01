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
        object aValue = 42;
        if (aValue is int)
        {
            Console.WriteLine($"aValue is an int");
        }
        if (aValue is int i)
        {
            Console.WriteLine($"aValue is an int and when I double it I get {i*2}");
        }

        if (aValue is 42 or 84 or 126)
        {
            // nice and short!
        }
        if (((int)aValue) == 42 || ((int)aValue) == 84 || ((int)aValue) == 126)
        {
            // convoluted and hard to read
        }

        object o = "string";
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
            _ => "gas", // instead of listing all possibilities, you can also use the discard pattern (the underscore)
        };


    public Task RunAsync()
    {
        throw new NotImplementedException();
    }
}


