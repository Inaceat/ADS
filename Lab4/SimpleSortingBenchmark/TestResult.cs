using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4.SimpleSortingBenchmark
{
    public class TestResult
    {
        private readonly int _dataSize;

        private readonly List<ResultEntry> _results;


        internal TestResult(int dataSize)
        {
            _dataSize = dataSize;

            _results = new List<ResultEntry>();
        }


        internal void AddEntry(ResultEntry resultEntry)
        {
            _results.Add(resultEntry);
        }


        public void PrintToConsole()
        {
            Console.WriteLine($"  {_dataSize} elements:");

            foreach (var entry in _results)
            {
                Console.WriteLine($"    {entry.Name, 10}: {entry.Time.TotalSeconds:F8} s., {entry.SwapCount} swaps, {entry.CompareCount} compares.");
            }



            Console.WriteLine($"    {"Average:",10}: " +
                              $"{_results.Average(entry => entry.Time.TotalSeconds):F8} s., " +
                              $"{_results.Average(entry => entry.SwapCount)} swaps, " +
                              $"{_results.Average(entry => entry.CompareCount)} compares.");

            Console.WriteLine();
        }
    }
}
