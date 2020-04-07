using System;
using System.Collections.Generic;
using System.Diagnostics;
using Lab4.SimpleSortingBenchmark.DataProviders;
using Lab4.Sorters;

namespace Lab4.SimpleSortingBenchmark
{
    internal class SortingTester
    {
        private readonly (int dataSize, int seed)[] _testConfigs;

        public SortingTester(ushort seed, params int[] dataSizes)
        {
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
            var dataSeedRNG = new Random(config.seed);

            var randomDataSeed = dataSeedRNG.Next();
            var ascendingDataSeed = dataSeedRNG.Next();
            var descendingDataSeed = dataSeedRNG.Next();
            

            var result = new TestResult(config.dataSize);


            //Test random data
            var randomDataProvider = new RandomIntDataGenerator(randomDataSeed);
            result.AddEntry("Random", DoTest(randomDataProvider, config.dataSize, sorter));


            //Test ascending data
            var ascendingDataProvider = new AscendingIntDataGenerator(ascendingDataSeed);
            result.AddEntry("Ascending", DoTest(ascendingDataProvider, config.dataSize, sorter));


            //Test descending data
            var descendingDataProvider = new DescendingIntDataGenerator(descendingDataSeed);
            result.AddEntry("Descending", DoTest(descendingDataProvider, config.dataSize, sorter));


            return result;
        }


        private ResultEntry DoTest(IIntDataGenerator dataGenerator, int dataSize, IIntegerArraySorter sorter)
        {
            //Time
            int[] data = dataGenerator.GetDataArray(dataSize);

            var timer = new Stopwatch();

            timer.Start();
            sorter.Sort(data);
            timer.Stop();


            //Find if sorting succeeded
            bool correctlySorted = true;
            for (int i = 0; i < data.Length - 1; ++i)
            {
                if (data[i] < data[i + 1]) 
                    continue;

                correctlySorted = false;
                break;
            }



            //Swaps & compares
            data = dataGenerator.GetDataArray(dataSize);

            (int swaps, int compares) = sorter.SortAndCountSwapsAndCompares(data);


            return new ResultEntry(correctlySorted, timer.Elapsed, swaps, compares);
        }
    }
}
