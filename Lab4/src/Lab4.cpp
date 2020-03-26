#include "stdafx.h"



void Foo()
{
	Sleep(400);
}


int main()
{
	std::cout << "start" << std::endl;


	auto start = std::chrono::steady_clock::now();

	Foo();

	auto end = std::chrono::steady_clock::now();


	auto elapsed = std::chrono::duration_cast<std::chrono::microseconds>(end - start).count();
	
	std::cout << elapsed << " us" << std::endl;
    
	return 0;
}