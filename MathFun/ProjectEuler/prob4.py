# I know that the first good candidate is 997799 and the way to
# progress the problem is 996699,995599... 989989 and so on.
# 997799 is the biggest palindrome less than 999*999 = 998001.

from math import sqrt

# quick function to convert the 3 digits of the palindrome to 
# a full int

def DigToNumber(x1, x2, x3):
	return x1*100001 + x2 * 10010 + x3 * 1100


# start with 997799

digit1 = 7
digit2 = 9
digit3 = 9
found = False

while not found:
	testNum = DigToNumber(digit3,digit2,digit1)

	# quick check to see if there are any 3 digit numbers that
	# divide my candidate.  I use a trick to cut down the amount
	# of numbers tried.

	for i in range(max(100,int(testNum/999)), int(sqrt(testNum))+1):
		if testNum % i == 0:
			found = True
			print "Divsor", i
			break # stop if it gets here.

	# now I need to adjust the digits accordingly or print if found.

	if found:
		print "Found", testNum
	else:
		if digit1 != 0:
			digit1 = digit1 - 1
		elif digit1 == 0 and digit2 != 0:
			digit1 = 9
			digit2 = digit2 - 1
		else:
			digit1 = 9
			digit2 = 9
			digit3 = digit3 - 1

