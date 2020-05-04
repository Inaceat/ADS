using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.Sorters
{
    class ListMergeSorter : IIntegerArraySorter
    {
        public void Sort(int[] data)
        {
            if (null == data)
                return;

            
            int size = data.Length;

            if (size < 2)
                return;


            int[] linkArray = new int[size + 2];


            unsafe
            {
                fixed (int* keys = &data[0], links = &linkArray[0])
                {
                //L1:
                    links[0] = 1;
                    links[size + 1] = 2;

                    links[size - 1] = links[size] = 0;

                    for (int i = 1; i <= size - 2; ++i)
                        links[i] = -(i + 2);


                L2:
                    int s = 0;
                    int t = size + 1;
                    int p = links[s];
                    int q = links[t];


                    if (0 == q)
                        goto End;


                L3:
                    if (keys[p-1] > keys[q-1])
                        goto L6;


                //L4:
                    links[s] = (links[s] * p < 0) ? -p : p;
                    s = p;
                    p = links[p];

                    if (p > 0)
                        goto L3;


                //L5:
                    links[s] = q;
                    s = t;

                    do
                    {
                        t = q;
                        q = links[q];
                    }
                    while (q > 0);

                    goto L8;


                L6:
                    links[s] = (links[s] * q < 0) ? -q : q;
                    s = q;
                    q = links[q];

                    if (q > 0)
                        goto L3;


                //L7:
                    links[s] = p;
                    s = t;

                    do
                    {
                        t = p;
                        p = links[p];
                    }
                    while (p > 0);

                    goto L8;
                    

                L8:
                    p = -p;
                    q = -q;

                    if (0 == q)
                    {
                        links[s] = (links[s] * p < 0) ? -p : p;
                        links[t] = 0;

                        goto L2;
                    }
                    else
                        goto L3;

                End:;

                }

                
                var clone = data.Clone() as int[];
                int nextIndex = linkArray[0];
                for (int i = 0; i < size; ++i)
                {
                    data[i] = clone[nextIndex - 1];
                    nextIndex = linkArray[nextIndex];
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

            int[] linkArray = new int[size + 2];


            unsafe
            {
                fixed (int* keys = &data[0], links = &linkArray[0])
                {
                //L1:
                    links[0] = 1;
                    links[size + 1] = 2;

                    links[size - 1] = links[size] = 0;

                    for (int i = 1; i <= size - 2; ++i)
                    {
                        ++compares;
                        links[i] = -(i + 2);
                    }
                    ++compares;


                L2:
                    int s = 0;
                    int t = size + 1;
                    int p = links[s];
                    int q = links[t];

                    ++compares;
                    if (0 == q)
                        goto End;


                L3:
                    ++compares;
                    if (keys[p-1] > keys[q-1])
                        goto L6;


                //L4:
                    ++compares;
                    links[s] = (links[s] * p < 0) ? -p : p;
                    s = p;
                    p = links[p];

                    ++compares;
                    if (p > 0)
                        goto L3;


                //L5:
                    links[s] = q;
                    s = t;

                    do
                    {
                        t = q;
                        q = links[q];

                        ++compares;
                    }
                    while (q > 0);

                    goto L8;


                L6:
                    ++compares;
                    links[s] = (links[s] * q < 0) ? -q : q;
                    s = q;
                    q = links[q];

                    ++compares;
                    if (q > 0)
                        goto L3;


                //L7:
                    links[s] = p;
                    s = t;

                    do
                    {
                        t = p;
                        p = links[p];

                        ++compares;
                    }
                    while (p > 0);

                    goto L8;
                    

                L8:
                    p = -p;
                    q = -q;

                    ++compares;
                    if (0 == q)
                    {
                        ++compares;
                        links[s] = (links[s] * p < 0) ? -p : p;
                        links[t] = 0;

                        goto L2;
                    }
                    else
                        goto L3;

                End:;

                }

                
                var clone = data.Clone() as int[];
                int nextIndex = linkArray[0];
                for (int i = 0; i < size; ++i)
                {
                    ++compares;

                    data[i] = clone[nextIndex - 1];
                    nextIndex = linkArray[nextIndex];
                }
                ++compares;
            }

            return (swaps, compares);
        }
    }
}
