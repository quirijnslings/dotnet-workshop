using System;
using System.Collections.Generic;
using System.Text;

namespace DotnetWorkshop.Examples;

internal class ExtensionMembersExample : ICodingExample
{
    public string Name => "Extension members";

    public bool IsAsync => false;

    public async Task RunAsync()
    {
        throw new NotImplementedException();
    }

    public void Run()
    {
        var months = Enum.GetValues<Months>();
        //var months = new List<Months>() { Months.January, Months.February, Months.March, Months.April, Months.May, Months.June };
        Console.WriteLine("The following months have always the same number of days:");
        foreach (var month in months.Where(m => m.AlwaysHasSameNumberOfDays))
        {
            Console.WriteLine($"- {month}");
        }
        Console.WriteLine("The following months have 31 days:");
        foreach (var month in months.GetMonthsWithDays(31))
        {
            Console.WriteLine($"- {month}");
        }

    }

}

public static class ExtensionMembers
{
    // Extension block
    extension(Months month) // extension members for the enum Months
    {
        // Extension property:
        public bool AlwaysHasSameNumberOfDays => month != Months.February;

        public int NumberOfDays => month switch
        {
            Months.April or Months.June or Months.September or Months.November => 30,
            Months.February => 28,
            _ => 31
        };

    }

    extension(IEnumerable<Months> months) // extension members for IEnumerable<Months>
    {
        // Extension method:
        public IEnumerable<Months> GetMonthsWithDays(int nrOfDays)
        {
            return months.Where(month => month.NumberOfDays == nrOfDays);
        }

    }

}

public enum Months
{
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}