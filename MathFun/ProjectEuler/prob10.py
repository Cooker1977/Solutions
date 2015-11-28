# find the sum of all primes below 2000000

from math import sqrt

# this is a helper routine to find the next prime given
# a list of the previous primes

def FindNext(primeList):
	divisionFound = True
	trying = primeList[len(primeList) - 1] + 2
	while divisionFound:
		divisionFound = False
		i = 0
		while primeList[i] <= sqrt(trying) and i < len(primeList):
			if trying % primeList[i] == 0:
				divisionFound = True
			i = i + 1
		if divisionFound:
			trying = trying + 2
	return trying

primes = [2,3]
sum = 5

while primes[len(primes)-1] < 2000000:
	primes.append(FindNext(primes))
	print "Prime Check", primes[len(primes) - 1]
	if primes[len(primes) - 1] < 2000000:
		sum = sum + primes[len(primes) - 1]

print "Answer", sum
