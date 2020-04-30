using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Sorters
{
    class QuickSorter : IIntegerArraySorter
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
                fixed (int* begin = &data[0])
                {
                    int* end = begin + size - 1;

                    DoQuickSort(begin, end);
                }
            }
            
        }


        private unsafe void SwapData(int* left, int* right)
        {
            int tmp = *left;
            *left = *right;
            *right = tmp;
        }


        private unsafe void DoQuickSort(int* begin, int* end)
        {
            //If size < 2
            if (end - begin < 1)
                return;

            //If size == 2
            if (end - begin == 1)
            {
                if (*end < *begin)
                    SwapData(begin, end);

                return;
            }


            int midValue = (int)(((long)*begin + *end + *(begin + (end - begin) / 2)) / 3);

            int* left = begin;
            int* right = end;

            while (true)
            {
                while (*left < midValue && left < right)
                    ++left;

                while (midValue <= *right && left < right)
                    --right;

                if (left < right)
                    SwapData(left, right);
                else
                    break;
            }

            //Now left == right
            if (*left < midValue)
                ++right;
            else
                --left;


            DoQuickSort(begin, left);
            DoQuickSort(right, end);
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
                fixed (int* begin = &data[0])
                {
                    int* end = begin + size - 1;

                    DoQuickSortAndCount(begin, end, ref swaps, ref compares);
                }
            }

            return (swaps, compares);
        }


        private unsafe void DoQuickSortAndCount(int* begin, int* end, ref int swaps, ref int compares)
        {
            //If size < 2
            if (end - begin < 1)
                return;

            //If size == 2
            if (end - begin == 1)
            {
                ++compares;
                if (*end < *begin)
                {
                    ++swaps;
                    SwapData(begin, end);
                }
                    

                return;
            }


            int midValue = (int)(((long)*begin + *end + *(begin + (end - begin) / 2)) / 3);

            int* left = begin;
            int* right = end;

            while (true)
            {
                while (*left < midValue && left < right)
                {
                    compares += 2;//for each compare in cycle condition check
                    ++left;
                }
                ++compares;//For failed cycle condition check


                while (midValue <= *right && left < right)
                {
                    compares += 2;
                    --right;
                }
                ++compares;


                ++compares;
                if (left < right)
                {
                    ++swaps;
                    SwapData(left, right);
                }
                else
                    break;
            }

            //Now left == right
            compares++;
            if (*left < midValue)
                ++right;
            else
                --left;


            DoQuickSortAndCount(begin, left, ref swaps, ref compares);
            DoQuickSortAndCount(right, end, ref swaps, ref compares);
        }
    }
}
