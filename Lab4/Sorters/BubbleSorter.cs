using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Sorters
{
    class BubbleSorter : IIntegerArraySorter
    {
        public void Sort(int[] data)
        {
            if (null == data)
                return;

            
            int size = data.Length;

            if (size < 2)
                return;


            unsafe
            {
                //C++ style addresses: [begin; end) arrays
                fixed (int* begin = &data[0])
                {
                    
                }
            }
            
        }
        

        public (int swaps, int compares) SortAndCountSwapsAndCompares(int[] data)
        {
            if (null == data)
                return (0, 0);

            
            int size = data.Length;

            if (size < 2)
                return (0, 0);

            int swaps = 0;
            int compares = 0;

            unsafe
            {
                //C++ style addresses: [begin; end) arrays
                fixed (int* begin = &data[0])
                {
                    
                }
            }

            return (swaps, compares);
        }
    }
}
