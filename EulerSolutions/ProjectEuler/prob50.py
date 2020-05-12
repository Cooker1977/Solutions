import math

class Sieve:
    PrimeList = [2]
    def __init__(self,x):
        BOOLLENGTH = (x+1)//2 - 1
        MAXINDEX = int(math.floor((math.sqrt(x) - 3) / 2)) + 1
        isPrime = []
        
        for i in range(BOOLLENGTH):
            isPrime.append(True)
        for i in range(MAXINDEX):
            if isPrime[i]:
                minIndex = ((2*i+3)*(2*i+3) -3)//2
                for j in range(minIndex,len(isPrime),(2*i+3)):
                    isPrime[j]=False

        for i in range(len(isPrime)):
            if isPrime[i]:
                self.PrimeList.append(2*i + 3)

def main():
    BigNum = 1000000
    y = Sieve(BigNum)

    # find the length of the the chain such that
    # all chains of that length are larger than BigNum
    total = 0
    count = 0
    while total <= BigNum and count < len(y.PrimeList):
        total += y.PrimeList[count]
        count += 1

    partialSums = [total]
    maxLen = count
    found = y.PrimeList[0],y.PrimeList[count-1],count,total

    # add all the chains of this length to a list and then
    # reverse the order, because working from biggest to smallest
    # is most productive later.
    for i in range(maxLen,len(y.PrimeList)):
        total = total + y.PrimeList[i] - y.PrimeList[i-maxLen]
        partialSums.append(total)

    partialSums.reverse()
    
    # now in a while loop I want to try progressively smaller lengths
    # until I find one that is actually a prime less that
    # big num.  Then this is our answer.  I also want to be
    # frugal with computations, so I want to make sure and
    # reuse as much calculation from the previous round as possible.
    while found[3] > BigNum:
        count -= 1
        nextSums = []
        for j,item in enumerate(partialSums):
            nextPartial = item - y.PrimeList[len(y.PrimeList) - 1 - count - j]
            if nextPartial < BigNum and nextPartial in y.PrimeList:
                found = y.PrimeList[len(y.PrimeList) - count - j], y.PrimeList[len(y.PrimeList) - 1 - j],count,nextPartial
                break
            else:
                nextSums.append(nextPartial)
        nextSums.append(partialSums[-1] - y.PrimeList[count])
        if nextSums[-1] < BigNum and nextSums[-1] in y.PrimeList:
            found = y.PrimeList[0], y.PrimeList[count - 1],count,nextSums[-1]
        partialSums = nextSums[:]

    print(found)
    
if __name__ == "__main__":
    main()
