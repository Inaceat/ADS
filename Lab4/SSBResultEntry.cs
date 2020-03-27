using System;

namespace Lab4
{
    internal class SSBResultEntry
    {
        private readonly int _dataSize;

        private readonly TimeSpan _timeRandom;
        private readonly int _swapCountRandom;
        private readonly int _compareCountRandom;


        public SSBResultEntry(int dataSize, TimeSpan timeRandom, int swapCountRandom, int compareCountRandom)
        {
            _dataSize = dataSize;
            _timeRandom = timeRandom;
            _swapCountRandom = swapCountRandom;
            _compareCountRandom = compareCountRandom;
        }


        public override string ToString()
        {
            return $"{_dataSize, -7} elements: {_timeRandom.TotalSeconds, 10} s., {_swapCountRandom, 5} swaps, {_compareCountRandom, 5} compares.";
        }
    }
}