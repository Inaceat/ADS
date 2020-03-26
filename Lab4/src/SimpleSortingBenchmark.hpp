#pragma once


typedef void(*Sorter)(int* begin, int* end);
typedef void(*SorterWithSwapAndCompareCounters)(int* begin, int* end, int& swapCount, int& compareCount);


void DoSortingTest(std::string name, Sorter sorter, SorterWithSwapAndCompareCounters sorterWithCounters);
