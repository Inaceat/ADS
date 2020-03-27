using System;
using System.Collections.Generic;

namespace Lab4
{
    public class SSBResult
    {
        private readonly string _name;

        private readonly List<SSBResultEntry> _results;


        internal SSBResult(string name)
        {
            _name = name;

            _results = new List<SSBResultEntry>();
        }

        internal void AddResult(int dataSize, TimeSpan time, int swapCount, int compareCount)
        {
            _results.Add(new SSBResultEntry(dataSize, time, swapCount, compareCount));
        }



        public void PrintToConsole()
        {
            Console.WriteLine($"{_name}: ");

            foreach (var entry in _results)
            {
                Console.WriteLine("  " + entry.ToString());
            }
        }
    }
}
