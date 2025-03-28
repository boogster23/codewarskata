def countdown(x):
    if x == 0:
        print("Blastoff!!!")
    else:
        print(x, "...")
        countdown(x - 1)

countdown(5)

def power(base, exp):
    if exp == 0:
        return 1
    else:
        return base * power(base, exp - 1)

print("Power of 2 to 4th:", power(2, 4))

def factorial(num):
    if num == 0:
        return 1
    else:
        return num * factorial(num - 1)
    
print("Factorial of 5:", factorial(5))
print("Factorial of 0:", factorial(0))