using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace DotnetWorkshop
{
    internal class StringExamples : ICodingExample
    {
        public void Run()
        {
            Console.WriteLine("Please view the code (StringExamples)");

            // string interpolation
            var msg = $"User '{name}' can be reached via email at {email}";
            // raw string literals
            var msg2 = """
                This is a string with "double" as well as 'single' quotes in it.
                It can also span multiple lines without the need for escape sequences.
                """;
            // raw string literals with more than three double quotes
            var msg3 = """"This is a string with no less than three """double""" quotes in it """";
            // raw string literals with interpolation
            var msg4 = $"""User "{name}" can be reached via email at "{email}" """;
            // verbatim strings (no escape possible!) 
            var path = @"C:\Data\Files\file.txt";

        }


        public Task RunAsync()
        {
            throw new NotImplementedException();
        }

        private string name = "Joe";
        private string email = "joe@acme.corp";

        public string Name => "String initialization and interpolation";

        public bool IsAsync => false;
    }


}
