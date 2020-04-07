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
            TestInsertionSort(bench);
            TestBubbleSort(bench);
            TestQuickSort(bench);

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

        private static void TestInsertionSort(SortingTester bench)
        {
            var insertionSorter = new InsertionSorter();
            
            var results = bench.Test("InsertionSorter", insertionSorter);
            
            Console.WriteLine("InsertionSorter:");
            
            foreach (TestResult result in results)
                result.PrintToConsole();
        }

        private static void TestBubbleSort(SortingTester bench)
        {
            var bubbleSorter = new BubbleSorter();
            
            var results = bench.Test("BubbleSorter", bubbleSorter);
            
            Console.WriteLine("BubbleSorter:");
            
            foreach (TestResult result in results)
                result.PrintToConsole();
        }

        private static void TestQuickSort(SortingTester bench)
        {
            var quickSorter = new QuickSorter();
            
            var results = bench.Test("QuickSorter", quickSorter);
            
            Console.WriteLine("QuickSorter:");
            
            foreach (TestResult result in results)
                result.PrintToConsole();
        }
    }
}
