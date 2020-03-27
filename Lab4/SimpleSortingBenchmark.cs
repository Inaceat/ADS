using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Lab4
{
    internal class SimpleSortingBenchmark
    {
        private int _seed;

        private (int size, int seed)[] _testConfigs;

        public SimpleSortingBenchmark(ushort seed, params int[] testSizes)
        {
            _seed = seed;

            _testConfigs = new (int size, int seed)[testSizes.Length];


            var configSeedGenerator = new Random(seed);

            for (var i = 0; i < testSizes.Length; ++i)
                _testConfigs[i] = (testSizes[i], configSeedGenerator.Next());
        }

        public SSBResult Test(string testName, IIntegerArraySorter sorter)
        {
            var result = new SSBResult(testName);


            var timer = new Stopwatch();

            timer.Start();
            Thread.Sleep(400);
            timer.Stop();

            foreach (var config in _testConfigs)
            {
                result.AddResult(config.size, timer.Elapsed, 0, 0);
            }
            

            return result;
        }




        static void Main(string[] args)
        {
            var bench = new SimpleSortingBenchmark(42, 10, 100, 1000, 10000);


            var x = new NonSorter();

            bench.Test("Dumb", x).PrintToConsole();
        }
    }
}
