import queue

import unittest
import io
import sys

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

if __name__ == '__main__':
    unittest.main()


