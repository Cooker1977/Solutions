#include "stdafx.h"
#include <iostream>

// Problem 1
//int main()
//{
//	std::cout << 3 + 4 << std::endl;
//	return 0;
//}

// Problem 2
//int main()
//{
//	std::cout << "This (\") is a quote, and this (\\) is a backslash." << std::endl;
//	return 0;
//}

// Problem 3
//int main()
//{
//	std::cout << "This (\") is a quote, \t and this (\\) is a backslash." << std::endl;
//	return 0;
//}

// Problem 4
//int main()
//{
//	std::cout << "// a small C++ program" << std::endl;
//	std::cout << "#include <iostream>" << std::endl << std::endl;
//	std::cout << "int main()" << std::endl;
//	std::cout << "{" << std::endl;
//	std::cout << "\tstd::cout << \"Hello, world!\" << std::endl;" << std::endl;
//	std::cout << "\treturn 0;" << std::endl;
//	std::cout << "}" << std::endl;
//}

// Problem 5 
// The sample code below is copied from the text. It doesn't code because the main method requires the braces
// to be a valid method
//int main() std::cout << "Hello, world!" << std::endl;

// Problem 6
// The sample below is valid. It just has many levels of scoping inside the main method
//int main() {{{{{{std::cout << "Hello, world!" << std::endl;}}}}}}

// Problem 7
// The sample below is not valid. Comments with /* don't nest. The first /* starts a comment
// that is then terminated by the first */. The second /* doesn't start a "nested comment, but
// is merely part of the comment already started. Therefore, the invalid phrase 
// "as its starting and ending delimiters */" is left dangling outside a comment.
//int main()
//{
//	/* This is a comment that extends over several lines
//	   because it uses /* and */ as its starting and ending delimiters */
//	std::cout << "Does this work?" << std::endl;
//	return 0;
//}

// Problem 8
// The sample below is valid. 
//int main()
//{
//	// This is a comment that extends over several lines
//	// by using // at the beginning of each line instead of using /*
//	// or */ to delimit comments.
//	std::cout << "Does this work?" << std::endl;
//	return 0;
//}

// Problem 9
//int main(){}

// Problem 10

int main()
{
	std
		::
		cout
		<<
		"Hello, world!"
		<<
		std
		::
		endl
	;
	return
		0
	;
}
