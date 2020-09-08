#include "stdafx.h"
#include <iostream>
#include <string>

// Problem 1
//int main()
//{
//	// This works because the + operator is left associative meaing
//	// that hello + ", world" is evaluated and yields a std::string as the
//	// left argument to the second +.
//	const std::string hello = "Hello";
//	const std::string message = hello + ", world" + "!";
//	return 0;
//}

// Problem 2
//int main()
//{
//	// This does not works because the + operator is left associative meaing
//	// that "Hello" + ", world" is evaluated first and fails, because + can't
//	// be used between 2 string literals.
//	const std::string exclam = "!";
//	const std::string message = "Hello" + ", world" + exclam;
//	return 0;
//}

// Problem 3
//int main()
//{
//	{ const std::string s = "a string";
//	  std::cout << s << std::endl; }
//	{ const std::string s = "another string";
//	  std::cout << s << std::endl; }
//	return 0;
//}

// Problem 4
// This does not compile due to the extra brace on line 44.
//int main()
//{
//	{ const std::string s = "a string";
//	std::cout << s << std::endl; }
//	{ const std::string s = "another string";
//	std::cout << s << std::endl; }}
//	return 0;
//}

// This also does not compile due to the extra brace on line 54.
//int main()
//{
//	{ const std::string s = "a string";
//	std::cout << s << std::endl; }
//	{ const std::string s = "another string";
//	std::cout << s << std::endl; };}
//	return 0;
//}

// Problem 5
// This does not compile due to accessing x after it is out of scope in line 65.
//int main()
//{
//	{ const std::string s = "a string";
//	{ std::string x = s + ", really";
//	  std::cout << s << std::endl; }
//	  std::cout << x << std::endl;
//	}
//	return 0;
//}

// Problem 6
// This does not compile due to accessing x after it is out of scope in line 65.
int main()
{
	std::cout << "What is your name? ";
	std::string name;
	std::cin >> name;
	std::cout << "Hello, " << name
	          << std::endl << "And what is yours? ";
	std::cin >> name;
	std::cout << "Hello, " << name
	          << "; nice to meet you too!" << std::endl;
	return 0;
}