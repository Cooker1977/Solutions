# This is just a first to see what the answer is for player 2 throwing 8 coins.

def Factorial(j):
	if j == 0:
		return 1
	else:
		return j*Factorial(j-1)

def Choose(i,j):
	return Factorial(i) / Factorial(j) / Factorial(i-j)

def NotProb1Coin(i):
	if i < 100:
		return 1
	else:
		sum = 0
		for j in range(100):
			sum += Choose(i,j)
		return pow(.5,i)*sum

def Prob8Wins(i):
	return pow(.5,8)*pow(1.0-pow(.5,8),i-1)

def ProbThreeStratWins(i):
	if i < 3:
		return 0.0
	else:
		sum = (pow(127.0/126,i-2) - 1) / (127.0/126 - 1)
		sum *= 127.0 / 126.0 * pow(9.0/8,i-1)
		sum -= (pow(127.0/112,i-2) - 1) / (127.0/112 - 1) * 127.0 / 112
		sum *= pow(7.0/8,i) / 127.0 / 49.0
		return sum 

sum = 0
for i in range(1,700):
	sum += Prob8Wins(i)*NotProb1Coin(i)

print sum
