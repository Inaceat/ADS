using System;
using Lab4.SimpleSortingBenchmark;

namespace Lab4
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            var bench = new SortingTester(42, 10, 100, 1000, 10000);


            var nonSorter = new NonSorter();

            var results = bench.Test("NonSorter", nonSorter);

            Console.WriteLine("NonSorter:");
            foreach (var result in results)
            {
                result.PrintToConsole();
            }
        }
    }
}
