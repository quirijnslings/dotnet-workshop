using DotnetWorkshop.Services;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;

namespace DotnetWorkshop.Examples
{
    internal class AnonymousTypesExample : ICodingExample
    {
        public string Name => "Anonymous types";

        public bool IsAsync => false;

        public async Task RunAsync()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {


            Console.WriteLine($"Place breakpoint in {this.GetType().Name} to view the code in action");

            // simple example of an anonymous type
            var p = new { Name = "Alice", Age = 30, Gender = "Female" };
            Console.WriteLine($"Person 1 is called{p.Name}");

            // use inferred member names
            var age = 25;
            var name = "Bob";
            var gender = "Male";
            var p2 = new { age, name, gender };
            Console.WriteLine($"Person 2 is {p2.age} years old");

            // p2.age = 43; // this is not possible, properties of an anonymous type are always read-only

            // you can reassign a value as long as the implicit class is the same
            p = new { Name = "Bob", Age = 25, Gender = "Male" };

           // p = new { Name = "Joey", Gender = "Male" }; // this is not possible because the implicit class is different!

            var t = p2.GetType();
            Console.WriteLine($"The anonymous type is called {t.Name}");


            // very useful in serialization scenarios, especially when calling a remote API
            string json = JsonSerializer.Serialize(p);
            Console.WriteLine("JSON: \r\n" + json);
            string json2 = JsonSerializer.Serialize(p2);
            Console.WriteLine("JSON with inferred members: \r\n" + json2);

            // example with linq projection
            var databaseService = new DatabaseService();

            var customers = databaseService.GetAllCustomers().Take(50);
            var mailAndPhone = customers.Select(customer =>
                new { customer.Email, customer.Phone }
            );

            foreach (var map in mailAndPhone)
            {
                Console.WriteLine($"{map.Email}; {map.Phone}");
            }

        }

        private (string, int) GetPerson()
        {
            return ("Alice", 30);
        }
    }
}
