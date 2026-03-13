using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotnetWorkshop.Examples
{
    internal class IterationsExample : ICodingExample
    {
        public string Name => "Iterations";

        public bool IsAsync => false;

        private IEnumerable<int> GetRandomNumbers()
        {
            List<int> randomNumbers = new List<int>();
            foreach (var number in seeds)
            {
                Thread.Sleep(1000); // Simulate slow operation 
                randomNumbers.Add(new Random().Next(number - 5, number + 5));
            }
            return randomNumbers;   
        }

        private IEnumerable<int> GetRandomNumbersParallel()
        {
            ConcurrentBag<int> randomNumbers = new ConcurrentBag<int>();
            Parallel.ForEach(seeds, number =>
            {
                Thread.Sleep(1000); // Simulate slow operation 
                randomNumbers.Add(new Random().Next(number - 5, number + 5));
            });
            return randomNumbers;
        }

        public async Task RunAsync()
        {
           throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine("First, I will generate 5 random numbers using a normal foreach");
            var sw = new Stopwatch();
            sw.Start();
            var randomNumbers = GetRandomNumbers();
            sw.Stop();
            Console.WriteLine($"Generating random numbers took {sw.ElapsedMilliseconds} ms\r\n\r\nHit any key to continue");
            Console.ReadKey();
            Console.WriteLine("Next, I will generate 5 random numbers using a Parallel.ForEach");
            sw.Restart();
            randomNumbers = GetRandomNumbersParallel();
            sw.Stop();
            Console.WriteLine($"Generating random numbers in parallel took {sw.ElapsedMilliseconds} ms\r\n\r\n");
        }
        private readonly int[] seeds = [1, 2, 3, 4, 5];
    }
}
