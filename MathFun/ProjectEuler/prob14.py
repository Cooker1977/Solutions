BigNum = 1000000

class SequenceLengths:
    def __init__(self):
        self.lookUp = {1:1}

    def get_count(self,x):
        if self.lookUp.has_key(x):
            return self.lookUp[x]
        else:
            return None

    def _getNextValue(self,x):
        if x % 2 == 0:
            return x / 2
        else:
            return 3*x + 1

    def extend(self,x):
        if not self.get_count(x):
            addList = [x]
            checkNext = self._getNextValue(x)
            while not self.get_count(checkNext):
                addList.append(checkNext)
                checkNext = self._getNextValue(checkNext)
            for i,item in enumerate(addList):
                self.lookUp[item] = len(addList) - i + self.get_count(checkNext)

maxLength = 1
maxStart = 1
lengths = SequenceLengths()
for i in range(2,BigNum):
    if not lengths.get_count(i):
        lengths.extend(i)
    if lengths.get_count(i) > maxLength:
        maxLength = lengths.get_count(i)
        maxStart = i

print maxLength, maxStart
