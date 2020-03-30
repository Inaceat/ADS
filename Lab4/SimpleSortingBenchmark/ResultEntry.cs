using System;

namespace Lab4.SimpleSortingBenchmark
{
    internal class ResultEntry
    {
        public string Name { get; }

        public TimeSpan Time { get; }
        public int SwapCount { get; }
        public int CompareCount { get; }


        public ResultEntry(string name, TimeSpan timeRandom, int swapCountRandom, int compareCountRandom)
        {
            Name = name;

            Time = timeRandom;
            SwapCount = swapCountRandom;
            CompareCount = compareCountRandom;
        }
    }
}