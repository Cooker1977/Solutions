
from math import sqrt

def PrimeFactorize(x):
    if x % 2 == 0:
        sieveLength = (x / 2) - 1
    else:
        sieveLength = (x+1) / 2
    checkLength = sqrt(x)
    sieve = []
    for i in range(0,sieveLength):
        sieve.append(True)
    
    for i in range(1,int(checkLength)/2+1):
        if sieve[i]:
            for j in range(2*i*i + 2*i,sieveLength, 2*i+1):
                if sieve[j]:
                    sieve[j] = False
    
    # hopefully the sieve has correctly identified the primes and now we just have to add them
    factors = [2]
    for i in range(0,sieveLength):
        if sieve[i]:
            sum = sum + 2*i + 1



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
