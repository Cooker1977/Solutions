# find the 10001st prime

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

while len(primes) < 10001:
    primes.append(FindNext(primes))

print "Answer", primes[len(primes) - 1]
