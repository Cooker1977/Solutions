# I will try this one with inelegant brute force.  I will take advantage of the
# fact that in order to leave room for an appropriate c, b < (1000 - a)/2
# and in order to leave room for b and c, a < (1000 - 2) / 3 or a < 333 to prevent
# totally wasteful checking

found = False

for a in range(1,333):
    for b in range(a+1,int((1000-a)/2)):
        if a*a + b*b == (1000 - a - b) * (1000 - a - b):
            print "Solution", a*b*(1000 - a - b)
            found = True
        if found:
            break
    if found:
        break
