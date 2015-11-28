
from math import sqrt

# a good way to quickly find the factors of a number

def FindFactors(x):
	factors = []
	for i in range(1, int(sqrt(x))+1):
		if x % i == 0:
			factors.append(i)
			factors.append(x / i)
	factors.sort()
	return factors

# iterate through the triangle numbers bigger than 28

i = 8
factorList = FindFactors((i*(i+1))/2)
while len(factorList) <= 500:
	i = i + 1
	factorList = FindFactors((i*(i+1))/2)
	print "Trying", (i*(i+1)) / 2

print "Answer", (i*(i+1)) / 2
