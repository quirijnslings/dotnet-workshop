using DotnetWorkshop.Services;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace DotnetWorkshop.Examples
{
    internal class DynamicTypeExample : ICodingExample
    {
        public string Name => "Dynamic type";

        public bool IsAsync => false;

        public async Task RunAsync()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine($"Place breakpoint in {this.GetType().Name} to view the code in action");


            dynamic dynamicItem = "hello world";
            Console.WriteLine($"Dynamic item (of type {dynamicItem.GetType().FullName}) contains a string of length {dynamicItem.Length}");

            dynamicItem = 100.01m;
            var t2 = dynamicItem * 9;

            Console.WriteLine($"Dynamic item (of type {dynamicItem.GetType().FullName}): {dynamicItem}");
            // it's ok to change the type however you want
            dynamicItem = new List<DateTime>() { DateTime.Now };
            Console.WriteLine($"Dynamic item (of type {dynamicItem.GetType().FullName}): {string.Join(", ", dynamicItem)}");
            dynamicItem = new
            {
                Name = "Alice",
                Age = 30,
                Gender = "Female"
            };

            // the following line will compile, but throws a runtime error!
            //t2 = dynType + 10;

            Console.WriteLine($"Dynamic item (of type {dynamicItem.GetType().FullName}): {dynamicItem.Name} is a {dynamicItem.Age} year old {dynamicItem.Gender}");

            dynamic d = 1;
            var testSum = d + 3;
            Console.WriteLine($"The sum of 'dynamic' and an integer, is also considere dynamic at compile time (and integer at runtime), see: {testSum.GetType().FullName}");

            testSum = $"The sum is {testSum}";
            Console.WriteLine($"Testsum has changed its type now: {testSum.GetType().FullName}");


        }

        private (string, int) GetPerson()
        {
            return ("Alice", 30);
        }
    }
}
