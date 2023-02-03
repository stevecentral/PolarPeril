import math

def iseven(num):
    if num % 2 == 0:
        return True
    return False


def fizzbuzz (maxnum):
    for i in range(1, maxnum):
        if i % 3 == 0 and i % 5 == 0:
            print(str(i) + " fizzbuzz")
        elif i % 3 == 0:
            print(str(i) + " fizz")
        elif i % 5 == 0:
                print(str(i) + " buzz")
        else:
                print(str(i))
                
#Find the maximum value in a lst without using max()
def find_max (array):
    max_num = array[0]
    for item in array:
        if max_num < item:
            max_num = item
    return max_num

def test1 (lst):
    for item in lst:
        print(item)
    for i in range(len(lst)):
        print(i)
        
def find_positives (array):
    positive_array = []
    for item in array:
        if item > 0:
            positive_array.append(item)
    return positive_array

def find_negatives (array):
    negative_array = []
    for item in array:
        if item > 0:
            negative_array.append(item)
    return negative_array

def categorize (array):
    negatives_array = []
    positives_array = []
    zeros_array = []
    for item in array:
        if item < 0:
            negatives_array.append(item)
        elif item > 0:
            positives_array.append(item)
        elif item == 0:
            zeros_array.append(item)
    return negatives_array, positives_array, zeros_array

def factorials (n):
    result = 1
    for i in range(1, n+1):
        result = result*i
    return result
    
def P (n, r):
    return factorials(n)/factorials(n-r)

def C (n, r):
    return factorials(n)/factorials(n-r)*factorials(r)

def root_finder (a, b, c):
    temp = b**2 - 4*a*c 
    if temp < 0:
        print(" the square root of -1 is i")
        return False
    root1 = (-b + math.sqrt(temp))/(2*a)
    root2 = (-b - math.sqrt(temp))/(2*a)
    return root1, root2

def infinity (n):
    i = 0
    while True:
        print(i)
        i = i+1
