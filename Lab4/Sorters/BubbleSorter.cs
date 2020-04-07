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
                //[first; last], INCLUSIVE arrays
                fixed (int* first = &data[0])
                {
                    int* last = first + size - 1;

                    //"wannabeCorrect" is place to have correct element after iteration
                    //last element is correct if all others are correct, so "wannabeCorrect" is from [first, last)
                    for (int* wannabeCorrect = first; wannabeCorrect < last; ++wannabeCorrect)
                    {
                        for (int* current = last; current > wannabeCorrect; --current)
                        {
                            if (*current < *(current - 1))
                            {
                                int tmp = *current;
                                *current = *(current - 1);
                                *(current - 1) = tmp;
                            }
                        }
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
                //[first; last], INCLUSIVE arrays
                fixed (int* first = &data[0])
                {
                    int* last = first + size - 1;

                    //"wannabeCorrect" is place to have correct element after iteration
                    //last element is correct if all others are correct, so "wannabeCorrect" is from [first, last)
                    for (int* wannabeCorrect = first; wannabeCorrect < last; ++wannabeCorrect)
                    {
                        for (int* current = last; current > wannabeCorrect; --current)
                        {
                            ++compares;

                            if (*current < *(current - 1))
                            {
                                int tmp = *current;
                                *current = *(current - 1);
                                *(current - 1) = tmp;

                                ++swaps;
                            }
                        }
                    }
                }
            }

            return (swaps, compares);
        }
    }
}
