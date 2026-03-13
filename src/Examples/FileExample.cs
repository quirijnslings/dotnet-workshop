using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotnetWorkshop.Examples
{
    internal class FileExample : ICodingExample
    {
        public string Name => "File operations";

        public bool IsAsync => false;

   

        public async Task RunAsync()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            Console.WriteLine($"Place breakpoint in {this.GetType().Name} to view the code in action");

            var filename = "pangrams.txt";

            // easy operations with text files, without worrying about opening/closing streams
            File.WriteAllText(filename, "The quick brown fox jumps over the lazy dog\r\n");
            File.AppendAllLines(filename, [ 
                "Mr. Jock, TV quiz Ph.D., bags few lynx", 
                "Lex bederft uw quiz met typisch vakjargon", 
                "Un jugoso zumo de piña y kiwi bien frío es exquisito y no lleva alcohol" ]);
            
            var allText = File.ReadAllText(filename);
            foreach (var line in File.ReadAllLines(filename))
            {
                Console.WriteLine("Pangram: " + line);
            }
        }
    }
}
