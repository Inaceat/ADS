using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab4.SimpleSortingBenchmark
{
    public class TestResult
    {
        private readonly int _dataSize;

        private readonly Dictionary<string, ResultEntry> _results;


        internal TestResult(int dataSize)
        {
            _dataSize = dataSize;

            _results = new Dictionary<string, ResultEntry>();
        }


        internal void AddEntry(string name, ResultEntry resultEntry)
        {
            _results.Add(name, resultEntry);
        }


        public void PrintToConsole()
        {
            Console.WriteLine($"  {_dataSize} elements:");

            foreach (var entry in _results)
            {
                Console.WriteLine($"    {entry.Key, 10}: " +
                                  (entry.Value.CorrectlySorted ? "   OK " : " FAIL ") +
                                  $"{entry.Value.Time.TotalSeconds:F8} s., " +
                                  $"{entry.Value.SwapCount} swaps, " +
                                  $"{entry.Value.CompareCount} compares.");
            }



            Console.WriteLine($"    {"Average:",10}: " +
                              "      " +
                              $"{_results.Average(entry => entry.Value.Time.TotalSeconds):F8} s., " +
                              $"{_results.Average(entry => entry.Value.SwapCount)} swaps, " +
                              $"{_results.Average(entry => entry.Value.CompareCount)} compares.");

            Console.WriteLine();
        }
    }
}
