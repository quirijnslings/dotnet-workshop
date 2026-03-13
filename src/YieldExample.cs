using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DotnetWorkshop
{
    internal class YieldExample : ICodingExample
    {
        public string Name => "Yield";

        public bool IsAsync => false;

       
        public async Task RunAsync()
        {
            throw new NotImplementedException();
        }

        public void Run()
        {
            foreach (var v in GetData().Where(a => a % 10 == 0))
            {
                Console.WriteLine(v);
            }
        }

        private IEnumerable<int> GetData()
        {
            foreach (var v in Enumerable.Range(1, 5000))
            {
                yield return v;
            }
        }
        private IEnumerable<int> GetDataTheOldWay()
        {
            var list = new List<int>();
            foreach (var v in Enumerable.Range(1, 5000))
            {
                list.Add(v);
            }
            return list;
        }
    }
}
