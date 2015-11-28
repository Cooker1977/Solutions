# The purpose of this code is to solve the following problem which is number 232 on project
# Euler.

# Two players share an unbiased coin and take it in turns to play "The Race". On Player 1's turn,
# he tosses the coin once: if it comes up Heads, he scores one point; if it comes up Tails, he
# scores nothing. On Player 2's turn, she chooses a positive integer T and tosses the coin T
# times: if it comes up all Heads, she scores 2^(T-1) points; otherwise, she scores nothing.
# Player 1 goes first. The winner is the first to 100 or more points.

# On each turn Player 2 selects the number, T, of coin tosses that maximises the probability of
# her winning.

# What is the probability that Player 2 wins?

# The method I am going to use is very straight forward, but clever.  The key is to realize
# that only the score is important and not get bogged down in rounds and what not. Let 
# P(i,j) be the probability that player 2 wins when player 1 has score i and player 2 has 
# the score j at the start of a turn.  If player 2 throws T coins then
# P(i,j) can be written in terms of the 4 possible outcomes weighted by their probabilty.

# P(99,99) is trivial to calculate and get 1/3.  This will let us calculate P(99,98) which
# lets us calculate P(99,98) etc.  At each step we will try all reasonable values for T and 
# only use the one that gives the largest result since we know that player 2 maximizes her winning
# chance.  Obviously, we need only try values from 1 to 2 + (int)log(100-j,2) ( I know this will
# try one extra term that is stupid when 100 - j is a perfect power of 2, but I will fix this in
# the code.

# lets begin

from math import log
from math import ceil

Target = 100

def ConstructStorage():
	b = []
	for i in range (0,Target):
		b.append([])
		for j in range(0,Target):
			b[i].append(float(0.0))
	return b

P = ConstructStorage()
Strat = ConstructStorage()

# start my outer loop

for i in range(Target - 1, -1, -1):
	for j in range(Target - 1, -1, -1):
		Tmax = int(ceil(log(float(Target - j),2))) + 1
		maxProb = 0.0
		for T in range(1,Tmax + 1):
			if (i+1 == Target) and (j + pow(2, T-1) >= Target):
				prob = 2.0 / (pow(2.0,T) + 1.0)
			elif (j + pow(2, T-1) >= Target):
                                prob = ((pow(2.0,T) - 1.0) * P[i+1][j] + 2.0) / (pow(2.0,T) + 1.0)
                                if P[i+1][j] == 0:
                                        print "Warning 1"
			elif (i+1 == Target):
				prob = P[i][j+pow(2,T-1)] / (pow(2.0,T) + 1.0)
				if P[i][j+pow(2,T-1)] == 0:
					print "Warning 2"
			else:
				prob = ((pow(2.0,T) - 1.0) * P[i+1][j] + P[i+1][j+pow(2,T-1)] + P[i][j+pow(2,T-1)]) / (pow(2.0,T) + 1.0)
				if P[i+1][j] == 0 or P[i][j+pow(2,T-1)] == 0 or P[i+1][j+pow(2,T-1)] == 0:
                                        print "Warning 3"

			if prob > maxProb:
				maxProb = prob
				Strat[i][j] = T

		P[i][j] = maxProb
		print i, j, P[i][j], Strat[i][j]


print 0.5*P[0][0]+0.5*P[1][0]

