using System;

namespace Lab4.SimpleSortingBenchmark
{
    internal class ResultEntry
    {
        public TimeSpan Time { get; }
        public int SwapCount { get; }
        public int CompareCount { get; }


        public ResultEntry(TimeSpan timeRandom, int swapCountRandom, int compareCountRandom)
        {
            Time = timeRandom;
            SwapCount = swapCountRandom;
            CompareCount = compareCountRandom;
        }
    }
}