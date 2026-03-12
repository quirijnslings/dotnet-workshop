
using DotnetWorkshop;
using System.Diagnostics;
using System.Threading.Tasks;

var exampleFactory = new ExampleRunner();
exampleFactory.Start();

//if (args.Length == 0)
//{
//    Console.WriteLine("Please specify which example to run (1, 2, or 3)");
//    return;
//}

//switch (args[0])
//{
//    case "1":
//        await Example1();
//        break;
//    case "2":
//        await Example2();
//        break;
//    case "3":
//        await Example3();
//        break;
//    case "4":
//        Example4();
//        break;
//    default:
//        Console.WriteLine("Invalid example number. Please specify 1, 2, or 3.");
//        break;
//}


//async static Task Example1()
//{
//    var sw = new Stopwatch();
//    sw.Start();
//    AsyncExamples.TestSync();
//    sw.Stop();
//    Console.WriteLine($"\r\nSynchronous operation took {sw.ElapsedMilliseconds} ms\r\n\r\n");
//    sw.Restart();
//    await AsyncExamples.TestAsyncPoorly();
//    sw.Stop();
//    Console.WriteLine($"\r\nAsynchonous operation without any efficiency gains took {sw.ElapsedMilliseconds} ms\r\n\r\n");
//    sw.Restart();
//    await AsyncExamples.TestAsyncProperly();
//    sw.Stop();
//    Console.WriteLine($"\r\nAsynchronous operation done properly took {sw.ElapsedMilliseconds} ms\r\n\r\n");
//}
//async Task Example2()
//{
//    var sw = new Stopwatch();
//    sw.Start();
//    var randomNumbers = IterationsExamples.GetRandomNumbers();
//    sw.Stop();
//    Console.WriteLine($"Generating random numbers took {sw.ElapsedMilliseconds} ms\r\n\r\n");
//    Console.WriteLine("Random numbers:");
//    foreach (var number in randomNumbers)
//    {
//        Console.WriteLine(number);
//    }
//    sw.Restart();
//    var randomNumbersAsync = await IterationsExamples.GetRandomNumbersAsync();
//    Console.WriteLine($"Generating random numbers inside an async method took {sw.ElapsedMilliseconds} ms\r\n\r\n");
//    Console.WriteLine("Random numbers:");
//    foreach (var number in randomNumbersAsync)
//    {
//        Console.WriteLine(number);
//    }

//}
//async Task Example3()
//{
//    var users = new List<User>
//    {
//        new PayingUser { Name = "Will", Age = 51, SubscriptionCost = 22.50m },
//        new User { Name = "Alice", Age = 30 },
//        new PayingUser { Name = "Bob", Age = 25, SubscriptionCost = 9.99m },
//        new User { Name = "Charlie", Age = 35 },
//        new PayingUser { Name = "Diana", Age = 28, SubscriptionCost = 14.99m }
//    };
//    foreach (var payingUser in users.OfType<PayingUser>())
//    {
//        Console.WriteLine($"{payingUser.Name} is a paying user with a subscription cost of {payingUser.SubscriptionCost:N2}");
//    }

//    PatternMatchingSwitchExample.Demo();
//}

//void Example4()
//{
//    var linqExamples = new LinqExamples();
//    linqExamples.Group();
//    linqExamples.DeferredExecution();
//}


