# find the sum of all primes below 2000000
# uses a trick to find primes quickly

from math import sqrt

sum = 2

# this finds all primes below 2000000 in the following way.
# first we eliminate all evens and start the sum at 2.
# now imagine all the odds.  Obviously every third odd is
# divisible by 3 and every 5th odd is divisible by 5.  We want
# to keep track of all factors of a new prime as we find it.
# also note that we only need to go up to sqrt(1999999) because 
# all the ones above this remaining will not be divisible by any of the smaller primes
# and will hence be prime.  Similarly, all the products below p^2 will have been eliminated
# Represent our list with a boolean


sieveLength = (2000000 / 2) - 1
checkLength = sqrt(2000000)

# initialize the sieve
# recall sieve[i] corresponds to the number 2i + 1

sieve = []
for i in range(0,sieveLength):
	sieve.append(True)

for i in range(1,int(checkLength)/2+1):
	if sieve[i]:
		for j in range(2*i*i + 2*i,sieveLength, 2*i+1):
			if sieve[j]:
				sieve[j] = False

# hopefully the sieve has correctly identified the primes and now we just have to add them
for i in range(0,sieveLength):
	if sieve[i]:
		sum = sum + 2*i + 1

print "Answer", sum
