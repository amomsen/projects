// max.cpp : Defines the entry point for the console application.
//
#include "stdafx.h"
#include <iostream>

using namespace std;

template <class T>
T max(T& t1, T& t2) 
{
	return t1<t2 ? t2 : t1;
}

int _tmain(int argc, _TCHAR* argv[])
{
	cout << "max of 33 and 44 is " << max(33, 44) << endl;
	string s1 = "hello";
	string s2 = "world";


	return 0;
}

