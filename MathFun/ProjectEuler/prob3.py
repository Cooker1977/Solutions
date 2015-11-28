# Euler Problem 3

# The prime factors of 13195 are 5, 7, 13 and 29.
# What is the largest prime factor of the number 600851475143 ?


#  find the largest prime that divides 600851475143.  I will first make a list of all factors
# of the big number (excluding 1 and the number itself).  Then I will make a list of primes 
#  that are smaller than or equal to the biggest factor in the factor list.  Then I will check for common
# elements efficiently.

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

# this is a function that will find out if a number is
# prime given a list of primes that goes up to the square
# root of the number

def PrimeCheck(primeList,x):
	i = 0
	isPrime = True
	while isPrime and primeList[i] <= int(sqrt(x)):
		if x % primeList[i] == 0:
			isPrime = False
		else:
			i = i + 1
	return isPrime

# first we find all the factors of the big number.

factors = []
bigNum = 600851475143
for i in range(3, int(round(sqrt(bigNum)))+1):
	if bigNum % i == 0:
		factors.append(i)
		factors.append(bigNum / i)

factors.sort()
print "Biggest factor", factors[len(factors) - 1]
primes = [2,3]

# now we find enough prime to check all factors for being prime

while primes[len(primes)-1] <= int(sqrt(factors[len(factors) - 1])):
	primes.append(FindNext(primes))

print "Biggest prime needed", primes[len(primes) - 1]

# now we start at the biggest factor and check if it is prime. Repeating for 
# all subsequent factors.

j = len(factors) - 1

while not PrimeCheck(primes,factors[j]) and j >= 0:
	j = j - 1

print "Answer", factors[j]
