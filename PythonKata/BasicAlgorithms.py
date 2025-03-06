import queue

import unittest
import io
import sys

class Node:
    def __init__(self, value):
        self.value = value
        self.next = None

def print_binary(n):
    if n <= 0:
        return

    q = queue.Queue()
    q.put(1)

    for i in range(n):
        current = q.get()
        print(current)
        q.put(current * 10)
        q.put(current * 10 + 1)

def has_matching_parentheses(s):
    stack = []
    for c in s:
        if c == '(':
            stack.append(c)

        if c == ')':
            if len(stack) == 0:
                return False
            stack.pop()

    return len(stack) == 0

def linked_list_cycle_using_hash(head):
    if head is None:
        return False

    hash_set = set()
    current = head

    while current is not None:
        if current in hash_set:
            return True

        hash_set.add(current)
        current = current.next

    return False

def is_palindrome_brute_force(teststr):
    temp = teststr.lower()

    newstr = ""
    for c in temp:
        if c.isalnum():
            newstr += c

    reversestr = ""
    strindx = len(newstr) - 1

    while (strindx >= 0):
        reversestr += newstr[strindx]
        strindx -= 1

    return newstr == reversestr        

class basic_algorithms_tests(unittest.TestCase):
    def test_print_binary(self):
        expected_output = "1\n10\n11\n100\n101\n"
        self.assertEqual(True, True)

        with io.StringIO() as captured_output:
            sys.stdout = captured_output
            print_binary(5)
            sys.stdout = sys.__stdout__ 

            self.assertEqual(captured_output.getvalue(), expected_output)

    def test_print_binary_zero_n(self):
        with io.StringIO() as captured_output:
            sys.stdout = captured_output
            print_binary(0)
            sys.stdout = sys.__stdout__

            self.assertEqual(captured_output.getvalue(), "")

    def test_has_matching_parentheses(self):
        self.assertEqual(has_matching_parentheses("()"), True)
        self.assertEqual(has_matching_parentheses("()()"), True)
        self.assertEqual(has_matching_parentheses("((((()))))"), True)
        self.assertEqual(has_matching_parentheses("(((())))"), True)
        self.assertEqual(has_matching_parentheses("((AA"), False)

    def test_linked_list_cycle_using_hash(self):
        head = Node(1)
        head.next = Node(2)
        head.next.next = Node(3)
        head.next.next.next = Node(4)
        head.next.next.next.next = head.next
        self.assertEqual(linked_list_cycle_using_hash(head), True)

    def test_linked_list_cycle_using_hash_no_cycle(self):
        head = Node(1)
        head.next = Node(2)
        head.next.next = Node(3)
        head.next.next.next = Node(4)
        self.assertEqual(linked_list_cycle_using_hash(head), False)

    def test_linked_list_cycle_using_hash_empty_list(self):
        self.assertEqual(linked_list_cycle_using_hash(None), False)

    def test_is_palindrome_brute_force(self):
        teststr = "kayak"
        self.assertTrue(is_palindrome_brute_force(teststr))

    def test_is_palindrome_brute_force_false(self):
        teststr = "amazing"
        self.assertFalse(is_palindrome_brute_force(teststr))

if __name__ == '__main__':
    unittest.main()


