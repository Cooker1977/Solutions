bigNum = open('prob8number.txt','r')
bigString = bigNum.read()

currentProd = 1
digitsList = []
maxProd = -10000
window = 13

for i in range(0, len(bigString)):
    if bigString[i] != '\n':
        currentProd = currentProd * int(bigString[i])
        digitsList.append(int(bigString[i]))
    
    if len(digitsList) > window:
        if digitsList[0] != 0:
            currentProd = currentProd / digitsList.pop(0)
        else:
            digitsList.pop(0)
            currentProd = 1
            for i in range(0, len(digitsList)):
                currentProd = currentProd * digitsList[i]
    
    if currentProd > maxProd:
        maxProd = currentProd
    
    print "Current Max is", maxProd
