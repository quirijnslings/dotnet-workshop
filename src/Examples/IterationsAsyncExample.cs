using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotnetWorkshop.Examples
{
    internal class IterationsAsyncExample : ICodingExample
    {
        public string Name => "Iterations (async)";

        public bool IsAsync => true;

        private async Task<IEnumerable<int>> GetRandomNumbersAsync()
        {
            ConcurrentBag<int> randomNumbers = new ConcurrentBag<int>();
            await Parallel.ForEachAsync(seeds, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, async (number, _) => 
            {
                await Task.Delay(1000); // Simulate asynchronous work
                randomNumbers.Add(new Random().Next(number - 5, number + 5));
            });
            return randomNumbers;
        }

        public async Task RunAsync()
        {
            var sw = new Stopwatch();
            sw.Start();
            var randomNumbersAsync = await GetRandomNumbersAsync();
            Console.WriteLine($"Generating random numbers inside an async method took {sw.ElapsedMilliseconds} ms\r\n\r\n");
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
        private readonly int[] seeds = [1, 2, 3, 4, 5];
    }
}
