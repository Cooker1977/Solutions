# Euler Problem 1

# If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6,
# and 9. The sum of these multiples is 23.
# Find the sum of all the multiples of 3 or 5 below 1000.

# This problem does not require a code.  You make use of the formula 1+2+3+...+N = N(N+1)/2.
# The sum of the multiples of 3 less than 1000 is 3*(1+2+3+...+333).  Similarly the sum of multiples
# of five less than 1000 is 5*(1+2+3+...199).  To prevent double counting (15, 30, etc. appear in both
# sums) you must subract off multiples of 15.  The sum of multiples of 15 less than 1000 is
# 15*(1+2+3...66).  Therefore, using the summing formula the final answer is
# 3*333*334/2 + 5*199*200/2 + 15*66*67/2 = 233168. No code required so I will put problem 2 in
# the same file.

# Euler Problem 2
# Each new term in the Fibonacci sequence is generated by adding the previous two terms. By 
# starting with 1 and 2, the first 10 terms will be:
# 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

# Find the sum of all the even-valued terms in the sequence which do not exceed four million.

# Solution code:
# this uses the closed form for the Fibonacci numbers to evaluate the sum of all
# even terms less than four million.  I also make use of the fact that the even valued terms
# correspond to 3i+3 for i = 0,1,2,3... to compute faster.

import math

# function to find the ith even Fibonacci number

def EvenFibonacci(i):
    n = int(3*i + 3)
    golden = (1 + math.sqrt(5)) / 2.0
    return round((math.pow(golden,n) - math.pow(-1/golden,n)) / math.sqrt(5))

sum = 0.0
j = 0
below = True

while below:
    temp = EvenFibonacci(j)
    if temp <= 4000000:
        sum = sum + temp
    else:
        below = False
    j = j+1

print sum
raw_input

# After running the code, I get the answer as 4613732 which is correct.