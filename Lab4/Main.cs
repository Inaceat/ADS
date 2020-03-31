using System;
using Lab4.SimpleSortingBenchmark;
using Lab4.Sorters;

namespace Lab4
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            var bench = new SortingTester(42, 10, 100, 1000, 10000);


            TestNonSort(bench);
            TestSelectionSort(bench);

        }


        private static void TestNonSort(SortingTester bench)
        {
            var nonSorter = new NonSorter();

            var results = bench.Test("NonSorter", nonSorter);

            Console.WriteLine("NonSorter:");
            
            foreach (var result in results)
                result.PrintToConsole();
        }

        private static void TestSelectionSort(SortingTester bench)
        {
            var selectionSorter = new SelectionSorter();

            var results = bench.Test("SelectionSorter", selectionSorter);

            Console.WriteLine("SelectionSorter:");
            
            foreach (TestResult result in results)
                result.PrintToConsole();
        }
    }
}
