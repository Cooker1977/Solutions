import math

def power(x,y):
    if y < 0:
        return power(1.0/x,-y)
    elif y==0:
        return 1
    return x*power(x,y-1)

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
                minIndex = ((2*i+3)*(2*i+3) -3)/2
                for j in range(minIndex,len(isPrime),(2*i+3)):
                    isPrime[j]=False

        for i in range(len(isPrime)):
            if isPrime[i]:
                self.PrimeList.append(2*i + 3)


def main():
    x = -2
    print power(2,x)
    y = Sieve(1000000)
    Winner = 0,0,0,0
    start = 0
    while len(y.PrimeList) - 1 - start > Winner[0]:
        end = start + Winner[0] + 1
        while end <= len(y.PrimeList):
            total = 0
            for i in range(start,end):
                total += y.PrimeList[i]
            if total in y.PrimeList:
                Winner = end - start, y.PrimeList[start],y.PrimeList[end-1],total
            end += 1
        start += 1

    print Winner

if __name__ == "__main__":
    main()
