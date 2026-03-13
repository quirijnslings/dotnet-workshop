using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotnetWorkshop
{
    internal class LinqExample : ICodingExample
    {
        private int[] scores = [97, 92, 81, 60];

        public string Name => "LINQ Operations";

        public bool IsAsync => false;

        public void MethodSyntax()
        {

            // Define the query expression.
            IEnumerable<int> scoreQuery = scores
                .Where(score => score > 80);
            // Execute the query.
            foreach (var i in scoreQuery)
            {
                Console.Write(i + " ");
            }
        }

        public void QuerySyntax()
        {
            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80 && score < 95
                select score;

            // Execute the query.
            foreach (var i in scoreQuery)
            {
                Console.Write(i + " ");
            }
        }

        public void Group()
        {
            var databaseService = new DatabaseService();
            var customers = databaseService.GetAllCustomers();

            var groupedByCountry = customers.GroupBy(c => c.Country);

            foreach (var group in groupedByCountry)
            {
                var averageRevenue = group.Average(c => c.Revenue);
                Console.WriteLine($"Country: {group.Key}, Average Revenue: {averageRevenue:N2}");
                foreach (var customer in group)
                {
                    Console.WriteLine($" - {customer.ContactName}");
                }
            }
        }

        public void DeferredExecution()
        {
            var databaseService = new DatabaseService();
            var ids = databaseService.GetAllIds();
            // query is defined but not executed until we iterate over the results
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var customers = ids.Select(id => databaseService.GetCustomer(id));
            sw.Stop();
            Console.WriteLine($"Defining the query took {sw.ElapsedMilliseconds} ms\r\n\r\n");

            // now, we will execute the query and print the results
            sw.Restart();
            foreach (var customer in customers)
            {
                //Console.WriteLine($"Found contact name {customer.ContactName} and email {customer.Email}");
            }
            sw.Stop();
            Console.WriteLine($"Iteration took {sw.ElapsedMilliseconds} ms\r\n\r\n");

            // we can execute the query more than once (unlike Java streams) - but it will cost time
            sw.Restart();
            foreach (var customer in customers)
            {
                //Console.WriteLine($"Found contact name {customer.ContactName} and email {customer.Email}");
            }
            sw.Stop();
            Console.WriteLine($"Iteration (#2) took {sw.ElapsedMilliseconds} ms\r\n\r\n");

            // alternatively, we can materialize the results into a list to avoid re-executing the query
            sw.Restart();
            var customerList = customers.ToList();
            sw.Stop();
            Console.WriteLine($"Conversion to list took {sw.ElapsedMilliseconds} ms\r\n\r\n");

            sw.Restart();
            foreach (var customer in customerList)
            {
                //Console.WriteLine($"Found contact name {customer.ContactName} and email {customer.Email}");
            }
            sw.Stop();
            Console.WriteLine($"Iteration over list took {sw.ElapsedMilliseconds} ms\r\n\r\n");

            sw.Restart();
            foreach (var customer in customerList)
            {
                //Console.WriteLine($"Found contact name {customer.ContactName} and email {customer.Email}");
            }
            sw.Stop();
            Console.WriteLine($"Iteration over list (#2) took {sw.ElapsedMilliseconds} ms\r\n\r\n");
        }

        public void Run()
        {
            MethodSyntax();
            QuerySyntax();
            Group();
            DeferredExecution();
        }

        public Task RunAsync()
        {
            throw new NotImplementedException();
        }
    }


}
