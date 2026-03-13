using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotnetWorkshop
{
    internal class TuplesExample : ICodingExample
    {
        public string Name => "Tuples";

        public bool IsAsync => false;

   

        public async Task RunAsync()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine($"Place breakpoint in {this.GetType().Name} to view the code in action");

            // simple example of a tuple
            var p = ("Alice", 30, "Female");

            // you can also use named tuples to give the values meaningful names
            var p2 = (Name: "Alice", Age: 30, Gender: "Female");

            // you can use tuples to group together multiple values without needing to define a class or struct for it
            var people = new List<(string, int)>
            {
                ("Bob", 25),
                ("Carol", 35),
                ("Dave", 40)
            };
            var firstNameInPeople = people.FirstOrDefault().Item1;

            // you can also use named tuples to give the values meaningful names
            var people2 = new List<(string Name, int Age)>
            {
                ("Bob", 25),
                ("Carol", 35),
                ("Dave", 40)
            };
            var firstNameInPeople2 = people2.FirstOrDefault().Name;

            // you can deconstruct tuples into separate variables
            foreach (var (name, age) in people)
            {
                Console.WriteLine($"{name} is {age} years old");
            }

            // you can return tuples from methods
            var person = GetPerson();
            // or deconstruct it directly
            var (name2, age2) = GetPerson();
        }

        private (string, int) GetPerson()
        {
            return ("Alice", 30);
        }
    }
}
