import math, threading, time
try:
    import psyco
    psyco.full()
except ImportError:
    pass

now = time.clock()

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

class sieveThread(threading.Thread):
    def __init__(self, large, mutex):
        self.large = large
        self.mutex = mutex
        threading.Thread.__init__(self)
    def run(self):
        y = Sieve(self.large).PrimeList[:]
        self.mutex.acquire()
        print y[-1]
        self.mutex.release()

outmutex = threading.Lock()
sieves = []

for i in range(4):
    newSieve = sieveThread(100*i + 5500000,outmutex)
    newSieve.start()
    sieves.append(newSieve)

''' my sieves are started, now I want to count the time in the main thread'''

count = 0
threadsToJoin = []
while len(threadsToJoin) < len(sieves):
    count += 1
    outmutex.acquire()
    print 'Counting', count
    outmutex.release()
    for thread in sieves:
        if not (thread.isAlive() or thread in threadsToJoin):
            threadsToJoin.append(thread)

for thread in sieves:
    thread.join()
print 'Main thread exiting.'
print 'TotalTime', time.clock()-now
