import unittest
from typing import List, Optional

from SinglyListNode import SinglyListNode

def two_sum(nums: List[int], target: int) -> List[int]:
    nums_map = {}
    
    for i, num in enumerate(nums):
        num_to_find = target - num
        if num_to_find in nums_map:
            return [num, num_to_find]
        
        nums_map[num] = i
    
    return nums_map

def container_with_most_water_height_brute_force(nums) -> int:
    max_area = 0

    for i in range(len(nums)):
        for j in range(i+1, len(nums)):
            height = min(nums[i], nums[j])
            width = j - i
            current_area = height * width
            max_area = max(current_area, max_area)

    return max_area

def container_with_most_water_height(nums) -> int:
    max_area = 0
    indexA = 0
    indexB = len(nums) - 1

    while indexB > indexA:
        height = min(nums[indexA], nums[indexB])
        width = indexB - indexA
        current_area = height * width
        max_area = max(current_area, max_area)
        if nums[indexA] < nums[indexB]:
            indexA += 1
        else:
            indexB -= 1

    return max_area

def shifting_linked_list(node, k):
    if not node or k == 0:
        return node

    length = 1
    tail = node

    while tail.next:
        tail = tail.next
        length += 1

    k = k % length

    if k == 0:
        return node

    if k < 0:
        k = k + length

    numTailPosition = length - k
    newTail = node

    for _ in range(numTailPosition - 1):
        newTail = newTail.next

    newHead = newTail.next
    newTail.next = None
    tail.next = node

    return newHead

class TestTwoSum(unittest.TestCase):
    def test_two_sum(self):
        nums = [15, 7, 11, 2]
        target = 9
        result = two_sum(nums, target)
        
        self.assertIsNotNone(result)
        self.assertIn(7, result)
        self.assertIn(2, result)

    def test_container_with_most_water_height_brute_force(self):
        nums = [1, 8, 6, 2, 5, 4, 8, 3, 7]
        result = container_with_most_water_height_brute_force(nums)
        self.assertEqual(result, 49)

    def test_container_with_most_water_height_brute_force_zero_result(self):
        nums = [1]
        result = container_with_most_water_height_brute_force(nums)
        self.assertEqual(result, 0)

    def test_container_with_most_water_height(self):
        nums = [1, 8, 6, 2, 5, 4, 8, 3, 7]
        result = container_with_most_water_height(nums)
        self.assertEqual(result, 49)

    def test_container_with_most_water_height_brute_force(self):
        nums = [1]
        result = container_with_most_water_height(nums)
        self.assertEqual(result, 0)

    def test_shifting_linklist(self):
        node1 = SinglyListNode(1)
        node2 = SinglyListNode(2)
        node3 = SinglyListNode(3)
        node4 = SinglyListNode(4)
        node5 = SinglyListNode(5)
        node1.next = node2
        node2.next = node3
        node3.next = node4
        node4.next = node5

        new_head = shifting_linked_list(node1, 2)
        self.assertEqual(new_head.value, 4)
        self.assertEqual(new_head.next.value, 5)
        self.assertEqual(new_head.next.next.value, 1)
        self.assertEqual(new_head.next.next.next.value, 2)
        self.assertEqual(new_head.next.next.next.next.value, 3)

if __name__ == "__main__":
    unittest.main()
