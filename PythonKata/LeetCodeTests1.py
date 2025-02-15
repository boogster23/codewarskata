import unittest
from typing import List, Optional

def two_sum(nums: List[int], target: int) -> Optional[List[int]]:
    nums_map = {}
    
    for i, num in enumerate(nums):
        num_to_find = target - num
        if num_to_find in nums_map:
            return [num, num_to_find]
        
        nums_map[num] = i
    
    return None

class TestTwoSum(unittest.TestCase):
    def test_two_sum(self):
        nums = [15, 7, 11, 2]
        target = 9
        result = two_sum(nums, target)
        
        self.assertIsNotNone(result)
        self.assertIn(7, result)
        self.assertIn(2, result)

if __name__ == "__main__":
    unittest.main()
