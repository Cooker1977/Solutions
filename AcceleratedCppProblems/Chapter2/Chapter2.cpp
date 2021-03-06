#include "stdafx.h"
#include <iostream>
#include <string>
using std::cin;
using std::endl;
using std::cout;
using std::string;

// Problem 1
//int main()
//{
//	// ask for the person's name
//	cout << "Please enter your first name: ";
//
//	// read the name
//	string name;
//	cin >> name;
//
//	// build the message that we intend to write
//	const string greeting = "Hello, " + name + "!";
//
//	// the number of blanks surrounding the greeting
//	const int pad = 0;
//
//	// the number of rows and columns to write
//	const int rows = pad * 2 + 3;
//	const string::size_type cols = greeting.size() + pad * 2 + 2;
//
//	// write a blank line to separate the output from the input
//	cout << endl;
//
//	// write `rows' rows of output
//	// invariant: we have written `r' rows so far
//	for (int r = 0; r != rows; ++r) {
//
//		string::size_type c = 0;
//
//		// invariant: we have written `c' characters so far in the current row
//		while (c != cols) {
//
//			// is it time to write the greeting?
//			if (r == pad + 1 && c == pad + 1) {
//				cout << greeting;
//				c += greeting.size();
//			}
//			else {
//
//				// are we on the border?
//				if (r == 0 || r == rows - 1 ||
//					c == 0 || c == cols - 1)
//					cout << "*";
//				else
//					cout << " ";
//				++c;
//			}
//		}
//
//		cout << endl;
//	}
//
//	return 0;
//}

// Problem 2
//int main()
//{
//	// ask for the person's name
//	cout << "Please enter your first name: ";
//
//	// read the name
//	string name;
//	cin >> name;
//
//	// build the message that we intend to write
//	const string greeting = "Hello, " + name + "!";
//
//	// the number of blanks surrounding the greeting
//	const int horizonalPadding = 20;
//	const int verticalPadding = 3;
//
//	// the number of rows and columns to write
//	const int rows = verticalPadding * 2 + 3;
//	const string::size_type cols = greeting.size() + horizonalPadding * 2 + 2;
//
//	// write a blank line to separate the output from the input
//	cout << endl;
//
//	// write `rows' rows of output
//	// invariant: we have written `r' rows so far
//	for (int r = 0; r != rows; ++r) {
//
//		string::size_type c = 0;
//
//		// invariant: we have written `c' characters so far in the current row
//		while (c != cols) {
//
//			// is it time to write the greeting?
//			if (r == verticalPadding + 1 && c == horizonalPadding + 1) {
//				cout << greeting;
//				c += greeting.size();
//			}
//			else {
//
//				// are we on the border?
//				if (r == 0 || r == rows - 1 ||
//					c == 0 || c == cols - 1)
//					cout << "*";
//				else
//					cout << " ";
//				++c;
//			}
//		}
//
//		cout << endl;
//	}
//
//	return 0;
//}

// Problem 3
//int main()
//{
//	// Ask for the amount of padding
//	cout << "Please enter the amount of spacing: ";
//
//	// read the padding
//	int pad;
//	cin >> pad;
//
//	// ask for the person's name
//	cout << "Please enter your first name: ";
//
//	// read the name
//	string name;
//	cin >> name;
//
//	// build the message that we intend to write
//	const string greeting = "Hello, " + name + "!";
//
//	// the number of blanks surrounding the greeting
//
//	// the number of rows and columns to write
//	const int rows = pad * 2 + 3;
//	const string::size_type cols = greeting.size() + pad * 2 + 2;
//
//	// write a blank line to separate the output from the input
//	cout << endl;
//
//	// write `rows' rows of output
//	// invariant: we have written `r' rows so far
//	for (int r = 0; r != rows; ++r) {
//
//		string::size_type c = 0;
//
//		// invariant: we have written `c' characters so far in the current row
//		while (c != cols) {
//
//			// is it time to write the greeting?
//			if (r == pad + 1 && c == pad + 1) {
//				cout << greeting;
//				c += greeting.size();
//			}
//			else {
//
//				// are we on the border?
//				if (r == 0 || r == rows - 1 ||
//					c == 0 || c == cols - 1)
//					cout << "*";
//				else
//					cout << " ";
//				++c;
//			}
//		}
//
//		cout << endl;
//	}
//
//	return 0;
//}

//// Problem 4
//int main()
//{
//	// ask for the person's name
//	cout << "Please enter your first name: ";
//
//	// read the name
//	string name;
//	cin >> name;
//
//	// build the message that we intend to write
//	const string greeting = "Hello, " + name + "!";
//
//	// the number of blanks surrounding the greeting
//	const int pad = 0;
//
//	// the number of rows and columns to write
//	const int rows = pad * 2 + 3;
//	const string::size_type cols = greeting.size() + pad * 2 + 2;
//	const string spaces(greeting.size() + pad * 2, ' ');
//	const string padding(pad, ' ');
//
//	// write a blank line to separate the output from the input
//	cout << endl;
//
//	// write `rows' rows of output
//	// invariant: we have written `r' rows so far
//	for (int r = 0; r != rows; ++r) {
//
//		string::size_type c = 0;
//
//		// invariant: we have written `c' characters so far in the current row
//		while (c != cols) {
//
//			// is it time to write the greeting?
//			if (r == pad + 1 && c == 1) 
//			{
//				cout << padding << greeting << padding;
//				c += greeting.size() + 2 * padding.size();
//			}
//			else {
//
//				// are we on the border?
//				if (r == 0 || r == rows - 1 ||
//					c == 0 || c == cols - 1)
//				{
//					cout << "*";
//					++c;
//				}
//				else
//				{
//					cout << spaces;
//					c += spaces.size();
//				}
//			}
//		}
//
//		cout << endl;
//	}
//
//	return 0;
//}

// Problem 5
int main()
{
	// ask for the length
	cout << "Please enter the length for the square, rectangle, and triangle: ";

	// read the length
	int length;
	cin >> length;

	// ask for the width
	cout << "Please enter the width for the rectangle and triangle: ";

	// read the width
	int width;
	cin >> width;

	cout << endl;

	// output the square on pass 0, rectangle on pass 1, and triangle on pass 2
	for (int k = 0; k < 3; ++k)
	{
		int currentWidth;
		if (k == 0)
			currentWidth = length;
		else
			currentWidth = width;

		for (int i = 0; i < length; ++i)
		{
			for (int j = 0; j < currentWidth; ++j)
			{
				bool endCondition;
				if (k == 2)
					endCondition = j == i * (currentWidth - 1) / (length - 1);
				else
					endCondition = j == currentWidth - 1 || i == 0;

				if (j == 0 || i == length - 1 || endCondition)
					cout << "* ";
				else
					cout << "  ";
			}
			cout << endl;
		}

		cout << endl;
		cout << endl;
	}
	cin >> width;

	return 0;
}