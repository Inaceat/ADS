﻿using System;
using System.Linq;

namespace Lab4.SimpleSortingBenchmark.DataProviders
{
    internal class AscendingIntDataGenerator : IIntDataGenerator
    {
        private readonly int _seed;


        public AscendingIntDataGenerator(int seed)
        {
            _seed = seed;
        }

        
        public int[] GetDataArray(int size)
        {
            var array = new int[size];

            var dataGenerator = new Random(_seed);

            for (int i = 0; i < size; ++i)
                array[i] = dataGenerator.Next(int.MinValue, int.MaxValue);

            
            return array.OrderBy(number => number).ToArray();
        }
    }
}
