using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetWorkshop
{
    public class GeneralSettings
    {
        public const string SectionName = "General";

        public string AppName { get; set; } = "Dotnet Workshop";
        public string Version { get; set; } = "1.0.0";
        public string Author { get; set; }
    }
}
