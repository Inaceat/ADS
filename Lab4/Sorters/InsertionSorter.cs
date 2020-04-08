using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Sorters
{
    class InsertionSorter : IIntegerArraySorter
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

                    for (int* elementToPlace = begin + 1; elementToPlace < end; ++elementToPlace)
                    {
                        int tmp = *elementToPlace;

                        //Now find first element <= tmp
                        int* current = elementToPlace - 1;
                        for (; current >= begin; --current)
                        {
                            if (*current <= tmp)
                                break;

                            *(current + 1) = *current;
                        }

                        *(current + 1) = tmp;
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

                    for (int* elementToPlace = begin + 1; elementToPlace < end; ++elementToPlace)
                    {
                        ++swaps;
                        int tmp = *elementToPlace;

                        //Now find first element <= tmp
                        int* current = elementToPlace - 1;
                        for (; current >= begin; --current)
                        {
                            ++compares;
                            if (*current <= tmp)
                                break;

                            ++swaps;
                            *(current + 1) = *current;
                        }

                        ++swaps;
                        *(current + 1) = tmp;
                    }
                }
            }

            return (swaps, compares);
        }
    }
}
