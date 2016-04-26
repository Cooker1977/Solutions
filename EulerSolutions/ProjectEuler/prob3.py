# Euler Problem 3

# The prime factors of 13195 are 5, 7, 13 and 29.
# What is the largest prime factor of the number 600851475143 ?

# I am going to take our unpleasant big number and divide it by its prime factors
# to remove than and keeping track of the last big prime that divided it.  I am
# also going to take advantage of the fact that any number can only have one prime
# bigger than sqrt(n) divides it.  This is easy to see.  Suppose p1 and p2 are both
# prime, bigger than sqrt(n), and divide n.  Sine p1 and p2 are prime, their greatest
# common factor is 1.  Therefore, p1*p2 must divide n.  But p1*p2 >sqrt(n)*sqrt(n) = n.
# Leading to a contradiction. I also have an efficient routine to find the next prime
# given all the previous primes.

from math import sqrt

# this is a helper routine to find the next prime given
# a list of the previous primes.  This assumes the list
# has been seeded with at least 2 and 3 so that we only 
# check odds.

def FindNext(primeList):
    divisionFound = True
    trying = primeList[len(primeList) - 1] + 2
    while divisionFound:
        divisionFound = False
        i = 0
        
        # here I only check the primes needed for dividing trying.
        
        while primeList[i] <= sqrt(trying) and i < len(primeList):
            if trying % primeList[i] == 0:
                divisionFound = True
            i = i + 1
        if divisionFound:
            trying = trying + 2
    return trying

# this routine divides out all powers of a given factor until it will no longer
# divide the number.  Then returns the result.

def RemoveFactor(composite, factor):
    factorized = composite
    if factor == 1:
        return composite
    while factorized % factor == 0:
        factorized = factorized / factor
    return factorized

bigNum = 600851475143
remainingFactors = bigNum
primes = [2,3]
biggest = 1

# for our problem the next two steps are obviously not needed since 2 and 3 clearly
# don't divide bigNum, but I am trying to keep the code general

if bigNum % 2 == 0:
    biggest = 2
    remainingFactors = RemoveFactor(remainingFactors,2)
if remainingFactors % 3 == 0:
    biggest = 3
    remainingFactors = RemoveFactor(remainingFactors,3)

while primes[len(primes) - 1] < sqrt(bigNum) and remainingFactors > 1:
    primes.append(FindNext(primes))
    if remainingFactors % primes[len(primes) - 1] == 0:
        biggest = primes[len(primes) - 1]
        remainingFactors = RemoveFactor(remainingFactors,primes[len(primes) - 1])

print "Answer", max(biggest,remainingFactors)
