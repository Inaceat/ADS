#include "stdafx.h"


#include "SimpleSortingBenchmark.hpp"


void Sort(int* begin, int* end)
{

}

void SortWithCounters(int* begin, int* end, int& swapCount, int& compareCount)
{
	swapCount = 42;
	compareCount = 43;
}


int main()
{
	DoSortingTest("qwe", Sort, SortWithCounters);


	std::cout << "start" << std::endl;


	auto start = std::chrono::steady_clock::now();

	//Foo();

	auto end = std::chrono::steady_clock::now();


	auto elapsed = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
	
	std::cout << elapsed << " us" << std::endl;
    
	return 0;
}