using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetWorkshop
{
    public interface ICodingExample
    {
        string Name { get; }
        void Run();
        Task RunAsync();
        bool IsAsync { get; }
    }
}
