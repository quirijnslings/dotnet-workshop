using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace DotnetWorkshop.Examples
{
    public class AsyncExamples : ICodingExample
    {

        public string Name => "Async operations";

        public bool IsAsync => true;

        public async Task RunAsync()
        {
            var text = """
            This example will demonstrate the difference between synchronous and asynchronous code by simulating the process of making breakfast. We'll compare three scenarios:
                
            1. Make breakfast using only synchronous code
            2. Make breakfast using asynchronous code without any efficiency gains
            3. Make breakfast using asynchronous code properly
            
                --------
                Hit any key to start
            """;
            Console.WriteLine(text);

            Console.ReadKey();
            Console.WriteLine("Making breakfast using only synchronous code");
            var sw = new Stopwatch();
            sw.Start();
            AsyncExamples.TestSync();
            sw.Stop();
            Console.WriteLine($"\r\nSynchronous operation took {sw.ElapsedMilliseconds} ms\r\n\r\nHit any key to continue");
            Console.ReadKey();
            Console.WriteLine("Making breakfast using asynchronous code without any efficiency gains");
            sw.Restart();
            await AsyncExamples.TestAsyncPoorly();
            sw.Stop();
            Console.WriteLine($"\r\nAsynchonous operation without any efficiency gains took {sw.ElapsedMilliseconds} ms\r\n\r\nHit any key to continue");
            Console.ReadKey();
            Console.WriteLine("Making breakfast using asynchronous code properly");
            sw.Restart();
            await AsyncExamples.TestAsyncProperly();
            sw.Stop();
            Console.WriteLine($"\r\nAsynchronous operation done properly took {sw.ElapsedMilliseconds} ms\r\n\r\nHit any key to continue");
        }
        public void Run()
        {
            throw new NotImplementedException();
        }

        public static void TestSync()
        {
            var juice = PourOJ();
            var toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            var eggs = FryEggs(2);
            var hashbrowns = FryHashBrowns(3);
            var coffee = PourCoffee();
            Console.WriteLine("Breakfast is ready!");
        }

        public static async Task TestAsyncPoorly()
        {
            var juice = PourOJ();
            var toast = await ToastBreadAsync(2);
            ApplyButter(toast);
            ApplyJam(toast);
            var eggs = await FryEggsAsync(2);
            var hashbrowns = await FryHashBrownsAsync(3);
            var coffee = PourCoffee();
            Console.WriteLine("Breakfast is ready!");
        }

        public static async Task TestAsyncProperly()
        {
            var juice = PourOJ();
            var toastTask = ToastBreadAsync(2);
            var eggsTask = FryEggsAsync(2);
            var hashbrownsTask = FryHashBrownsAsync(3);
            Console.WriteLine("Started the most time-consuming tasks...");
            var toast = await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            var coffee = PourCoffee();
            await Task.WhenAll(eggsTask, hashbrownsTask);
            Console.WriteLine("Breakfast is ready!");
        }



        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            var toast = await Task.Run(() => ToastBread(slices));
            return toast;
        }
        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }


        private static async Task<HashBrown> FryHashBrownsAsync(int patties)
        {
            var hashbrowns = await Task.Run(() => FryHashBrowns(patties));
            return hashbrowns;
        }

        private static HashBrown FryHashBrowns(int patties)
        {
            Console.WriteLine($"putting {patties} hash brown patties in the pan");
            Console.WriteLine("cooking first side of hash browns...");
            Task.Delay(3000).Wait();
            for (int patty = 0; patty < patties; patty++)
            {
                Console.WriteLine("flipping a hash brown patty");
            }
            Console.WriteLine("cooking the second side of hash browns...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put hash browns on plate");

            return new HashBrown();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            var eggs = await Task.Run(() => FryEggs(howMany));
            return eggs;
        }
        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }



     

        class Juice { }
        class Coffee { }
        class HashBrown { }
        class Toast { }
        class Egg { }
      
    }
}
