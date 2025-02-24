import unittest
from typing import List

from SinglyListNode import SinglyListNode

def two_sum_brute_force(nums, target):
    for i in range(len(nums)):
        for j in range(i, len(nums)):
            current_sum = nums[i] + nums[j]
            if current_sum == target:
                return [nums[i], nums[j]]

    return []


def two_sum(nums, target):
    nums_map = {}
    
    for i, num in enumerate(nums):
        num_to_find = target - num
        if num_to_find in nums_map:
            return [num, num_to_find]
        
        nums_map[num] = i
    
    return {}

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

def shifting_linked_list(head, k):
    if not head or k == 0:
        return head

    length = 1
    tail = head

    while tail.next:
        tail = tail.next
        length += 1

    k = k % length

    if k == 0:
        return head

    if k < 0:
        k = k + length

    numTailPosition = length - k
    newTail = head

    for _ in range(numTailPosition - 1):
        newTail = newTail.next

    newHead = newTail.next
    newTail.next = None
    tail.next = head

    return newHead

def trapping_rain_water_brute_force(heights):
    total_water = 0
    for i in range(1, len(heights) - 1):
        left_max = max(heights[:i])
        right_max = max(heights[i+1:])
        current_height = heights[i]
        water = min(left_max, right_max) - current_height
        total_water += max(water, 0)
    return total_water

def trapping_rain_water(heights):
    pLeft = 0
    pRight = len(heights) - 1
    maxLeft = 0
    maxRight = 0
    totalWater = 0

    while pLeft < pRight:
        if heights[pLeft] < heights[pRight]:
            if maxLeft > heights[pLeft]:
                totalWater += maxLeft - heights[pLeft]
            else:
                maxLeft = heights[pLeft]

            pLeft += 1
        else:
            if maxRight > heights[pRight]:
                totalWater += maxRight - heights[pRight]
            else:
                maxRight = heights[pRight]
            pRight -= 1

    return totalWater

def largest_rectangle_histogram_brute_force(heights):
    max_area = 0
    n = len(heights)

    for i in range(n):
        for j in range(i, n):
            min_height = float('inf')
            for k in range(i, j + 1):
                min_height = min(min_height, heights[k])

            area = min_height * (j - i + 1)
            max_area = max(max_area, area)

    return max_area

def largest_rectangle_histogram(heights):
    max_area = 0
    heights = heights + [0]
    stack = []
   
    for i, height in enumerate(heights):
        while stack and heights[stack[-1]] > height:
            top = stack.pop()
            width = i if not stack else i - stack[-1] - 1
            area = heights[top] * width
            max_area = max(max_area, area)
        stack.append(i)

    return max_area    

class TestTwoSum(unittest.TestCase):
    def test_two_sum_brute_force(self):
        nums = [15, 7, 11, 2]
        target = 9
        result = two_sum_brute_force(nums, target)
        
        self.assertIsNotNone(result)
        self.assertIn(7, result)
        self.assertIn(2, result)

    def test_two_sum_brute_force_empty(self):
        nums = [15]
        target = 9
        result = two_sum_brute_force(nums, target)
        
        self.assertIsNotNone(result)
        self.assertEqual(len(result), 0)

    def test_two_sum(self):
        nums = [15, 7, 11, 2]
        target = 9
        result = two_sum(nums, target)
        
        self.assertIsNotNone(result)
        self.assertIn(7, result)
        self.assertIn(2, result)

    def test_two_sum_empty(self):
        nums = [15]
        target = 9
        result = two_sum(nums, target)
        
        self.assertIsNotNone(result)
        self.assertEqual(len(result), 0)

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

    def test_container_with_most_water_height_brute_force_zerp(self):
        nums = [1]
        result = container_with_most_water_height(nums)
        self.assertEqual(result, 0)

    def test_shifting_linklist_right(self):
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

    def test_shifting_linklist_left(self):
        node1 = SinglyListNode(1)
        node2 = SinglyListNode(2)
        node3 = SinglyListNode(3)
        node4 = SinglyListNode(4)
        node5 = SinglyListNode(5)
        node1.next = node2
        node2.next = node3
        node3.next = node4
        node4.next = node5

        new_head = shifting_linked_list(node1, -2)
        self.assertEqual(new_head.value, 3)
        self.assertEqual(new_head.next.value, 4)
        self.assertEqual(new_head.next.next.value, 5)
        self.assertEqual(new_head.next.next.next.value, 1)
        self.assertEqual(new_head.next.next.next.next.value, 2)

    def test_shifting_linklist_circular(self):
        node1 = SinglyListNode(1)
        node2 = SinglyListNode(2)
        node3 = SinglyListNode(3)
        node4 = SinglyListNode(4)
        node5 = SinglyListNode(5)
        node1.next = node2
        node2.next = node3
        node3.next = node4
        node4.next = node5

        new_head = shifting_linked_list(node1, 5)
        self.assertEqual(new_head.value, 1)
        self.assertEqual(new_head.next.value, 2)
        self.assertEqual(new_head.next.next.value, 3)
        self.assertEqual(new_head.next.next.next.value, 4)
        self.assertEqual(new_head.next.next.next.next.value, 5)

    def test_trapping_rain_water_brute_force_1(self):
        heights = [0,1,0,2,1,0,1,3,2,1,2,1]
        result = trapping_rain_water_brute_force(heights)
        self.assertEqual(result, 6)

    def test_trapping_rain_water_brute_force_2(self):
        heights = [0,1,0,2,1,0,3,1,0,1,2]
        result = trapping_rain_water_brute_force(heights)
        self.assertEqual(result, 8)

    def test_trapping_rain_water_brute_force_zero(self):
        heights = [0,1,0]
        result = trapping_rain_water_brute_force(heights)
        self.assertEqual(result, 0)

    def test_trapping_rain_water_1(self):
        heights = [0,1,0,2,1,0,1,3,2,1,2,1]
        result = trapping_rain_water(heights)
        self.assertEqual(result, 6)

    def test_trapping_rain_water_2(self):
        heights = [0,1,0,2,1,0,3,1,0,1,2]
        result = trapping_rain_water(heights)
        self.assertEqual(result, 8)

    def test_trapping_rain_water_zero(self):
        heights = [0,1,0]
        result = trapping_rain_water(heights)
        self.assertEqual(result, 0)

    def test_largest_rectangle_histogram_brute_force(self):
        heights = [2,1,5,6,2,3]
        result = largest_rectangle_histogram_brute_force(heights)
        self.assertEqual(result, 10)

    def test_largest_rectangle_histogram(self):
        heights = [2,1,5,6,2,3]
        result = largest_rectangle_histogram(heights)
        self.assertEqual(result, 10)

if __name__ == "__main__":
    unittest.main()
