using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Lab4.SimpleSortingBenchmark
{
    internal class SortingTester
    {
        private int _seed;

        private readonly (int dataSize, int seed)[] _testConfigs;

        public SortingTester(ushort seed, params int[] dataSizes)
        {
            _seed = seed;

            _testConfigs = new (int size, int seed)[dataSizes.Length];


            var configSeedGenerator = new Random(seed);

            for (var i = 0; i < dataSizes.Length; ++i)
                _testConfigs[i] = (dataSizes[i], configSeedGenerator.Next());
        }


        public List<TestResult> Test(string testName, IIntegerArraySorter sorter)
        {
            var results = new List<TestResult>();
            
            foreach (var config in _testConfigs)
            {
                results.Add(TestSorter(config, sorter));
            }

            return results;
        }


        private TestResult TestSorter((int dataSize, int seed) config, IIntegerArraySorter sorter)
        {
            var result = new TestResult(config.dataSize);

            var dataSeedRNG = new Random(config.seed);


            //Test random data
            var randomDataSeed = dataSeedRNG.Next();
            var randomDataRNG = new Random(randomDataSeed);

            //Time test
            var randomData = new int[config.dataSize];
            var randomDataCopy = new int[config.dataSize];
            for (var i = 0; i < randomData.Length; ++i)
            {
                randomData[i] = randomDataRNG.Next(int.MinValue, int.MaxValue);
                randomDataCopy[i] = randomData[i];
            }


            var timer = new Stopwatch();

            timer.Start();
            sorter.Sort(randomData);
            timer.Stop();


            //Swap & compare test
            var (swaps, compares) = sorter.SortAndCountSwapsAndCompares(randomDataCopy);


            var randomResultEntry = new ResultEntry("Random", timer.Elapsed, swaps, compares);
            result.AddEntry(randomResultEntry);


            //Test ascending data

            var ascendingResultEntry = new ResultEntry("Ascending", TimeSpan.Zero, 0, 0);
            result.AddEntry(ascendingResultEntry);


            //Test descending data

            var descendingResultEntry = new ResultEntry("Descending", TimeSpan.Zero, 0, 0);
            result.AddEntry(descendingResultEntry);


            return result;
        }



    }
}
