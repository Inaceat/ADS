using System;

namespace Lab4.SimpleSortingBenchmark
{
    internal class ResultEntry
    {
        public bool CorrectlySorted { get; }

        public TimeSpan Time { get; }
        public int SwapCount { get; }
        public int CompareCount { get; }


        public ResultEntry(bool correctlySorted, TimeSpan timeRandom, int swapCountRandom, int compareCountRandom)
        {
            CorrectlySorted = correctlySorted;

            Time = timeRandom;
            SwapCount = swapCountRandom;
            CompareCount = compareCountRandom;
        }
    }
}