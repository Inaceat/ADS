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


            TestSorter(bench, new SelectionSorter());
            TestSorter(bench, new BubbleSorter());
            TestSorter(bench, new InsertionSorter());
            TestSorter(bench, new QuickSorter());
            TestSorter(bench, new ListMergeSorter());
        }


        private static void TestSorter(SortingTester tester, IIntegerArraySorter sorter)
        {
            var sorterName = sorter.GetType().Name;
            
            var results = tester.Test(sorterName, sorter);

            Console.WriteLine($"{sorterName}:");
            
            foreach (var result in results)
                result.PrintToConsole();

            Console.WriteLine(new string('-', 70));
        }
    }
}
