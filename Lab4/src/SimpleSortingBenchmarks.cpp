#include "stdafx.h"


#include "SimpleSortingBenchmark.hpp"



void DoSortingTest(std::string name, int dataSeed, 
	Sorter sorter, SorterWithSwapAndCompareCounters sorterWithCounters)
{
	int dataSizes[] = { 10, 100, 1000, 10000 };
	
	
	std::cout << name << ":" << std::endl;


	std::mt19937 seedREng(dataSeed);
	std::uniform_int_distribution<int> uniformDistribution(INT_MIN, INT_MAX);
	
	
	for (auto dataSize : dataSizes)
	{
	//Random data
		//Create data
		auto timeTestData = new int[dataSize];
		auto swapCompareTestData = new int[dataSize];

		for (int i = 0; i < dataSize; ++i)
		{
			timeTestData[i] = uniformDistribution(seedREng);
			swapCompareTestData[i] = timeTestData[i];
		}


		//Get time
		auto start = std::chrono::steady_clock::now();

		sorter(timeTestData, timeTestData + dataSize);

		auto end = std::chrono::steady_clock::now();


		//Get swaps & compares
		int swaps = 0;
		int compares = 0;

		sorterWithCounters(swapCompareTestData, swapCompareTestData + dataSize, swaps, compares);


		//Print results
		auto elapsed = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();

		
		std::cout << "  " << 
			std::setw(7) << dataSize << ":" <<
			std::setw(10) << elapsed << " us, " <<
			std::setw(7) << swaps << " swaps, " <<
			std::setw(7) << compares << " compares" <<
			std::endl;
	}



	std::cout << "  xxx swaps, yyy compares" << std::endl;
}
