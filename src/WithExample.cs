using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotnetWorkshop;

internal class WithExample : ICodingExample
{
    public string Name => "Use of 'with'";

    public bool IsAsync => false;

   
    public async Task RunAsync()
    {
        throw new NotImplementedException();
    }

    public void Run()
    {
        Console.WriteLine($"Place breakpoint in {this.GetType().Name} to view the code in action");
        var rex = new Pet(Name: "Rex", Age: 5, Species: "Dog");
        var buddy = rex with { Name = "Buddy" };
        var alsoBuddy = new Pet(Name: "Buddy", Age: rex.Age, Species: rex.Species);
        var whiskers = rex with { Name = "Whiskers", Species = "Cat" };
    }
}

internal record Pet(string Name, int Age, string Species);
