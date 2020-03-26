#include "stdafx.h"


#include "SimpleSortingBenchmark.hpp"
#include <iomanip>


void DoSortingTest(std::string name, Sorter sorter, SorterWithSwapAndCompareCounters sorterWithCounters)
{
	int dataSizes[] = { 10, 100, 1000, 10000 };
	//int dataSizesSize = sizeof(dataSizes) / sizeof(int);

	
	std::cout << name << ":" << std::endl;

	for (auto dataSize : dataSizes)
	{
		


		auto start = std::chrono::steady_clock::now();

		//Foo();

		auto end = std::chrono::steady_clock::now();

		auto elapsed = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();

		int swaps = 10;
		int compares = 12;


		std::cout << "  " << 
			std::setw(7) << dataSize << ":" <<
			std::setw(10) << elapsed << " us, " <<
			std::setw(7) << swaps << " swaps, " <<
			std::setw(7) << compares << " compares" <<
			std::endl;
	}



	std::cout << "  xxx swaps, yyy compares" << std::endl;
}
