using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Sorters
{
    class SelectionSorter : IIntegerArraySorter
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
                    int* end = begin + size;

                    
                    for (int* current = begin; current < end-1; ++current)
                    {
                        //Find min elemennt in non-sorted part of array
                        int* min = current;

                        for (int* possibleMin = current; possibleMin < end; ++possibleMin)
                        {
                            if (*possibleMin < *min)
                                min = possibleMin;
                        }

                        //Swap min with current
                        int tmp = *min;
                        *min = *current;
                        *current = tmp;
                    }
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
                    int* end = begin + size;

                    
                    for (int* current = begin; current < end-1; ++current)
                    {
                        //Find min elemennt in non-sorted part of array
                        int* min = current;

                        for (int* possibleMin = current; possibleMin < end; ++possibleMin)
                        {
                            compares++;
                            if (*possibleMin < *min)
                                min = possibleMin;
                        }

                        //Swap min with current
                        swaps++;

                        int tmp = *min;
                        *min = *current;
                        *current = tmp;
                    }
                }
            }

            return (swaps, compares);
        }
    }
}
