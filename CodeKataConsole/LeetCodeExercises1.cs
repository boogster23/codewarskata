using NUnit.Framework;

namespace CodeKataConsole
{
    public class LeetCodeExercises1
    {
        #region TwoSum
        public static int[] TwoSumBruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    var currentSum = nums[j] + nums[i];
                    if (currentSum == target)
                    {
                        return [nums[i], nums[j]];
                    }
                }
            }

            return [];
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            var numsMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                var numToFind = target - nums[i];
                if (numsMap.TryGetValue(numToFind, out _))
                {
                    return [nums[i], numToFind];
                }

                numsMap[nums[i]] = i;
            }

            return [];
        }
        #endregion

        #region ContainerWithMostWater
        public static int ContainerWithMostWaterBruteForce(int[] nums)
        {
            int maxArea = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    var height = Math.Min(nums[i], nums[j]);
                    var width = j - i;
                    var currentArea = height * width;
                    maxArea = Math.Max(currentArea, maxArea);
                }
            }

            return maxArea;
        }

        public static int ContainerWithMostWater(int[] nums)
        {
            int maxArea = 0;
            int pLeft = 0;
            int pRight = nums.Length - 1;

            while (pRight > pLeft)
            {
                var height = Math.Min(nums[pLeft], nums[pRight]);
                var width = pRight - pLeft;
                var currentArea = height * width;
                maxArea = Math.Max(currentArea, maxArea);

                if (nums[pLeft] <= nums[pRight])
                {
                    pLeft++;
                }
                else
                {
                    pRight--;
                }
            }

            return maxArea;
        }
        #endregion

        #region ShiftingLinkedList
        public static Node? ShiftingLinkedList(Node head, int k)
        {
            if (head == null || k == 0)
                return head;

            int length = 1;
            Node tail = head;
            while (tail.Next != null)
            {
                tail = tail.Next;
                length++;
            }

            k = k % length;

            if (k == 0) // full circle
                return head;

            if (k < 0)
            {
                k = k + length;
            }

            var newTailPosition = length - k;
            Node newTail = head;
            for (int i = 1; i < newTailPosition; i++)
            {
                newTail = newTail.Next;
            }

            Node newHead = newTail.Next;
            newTail.Next = null;
            tail.Next = head;

            return newHead;
        }
        #endregion

        #region TrappingRainWater
        public static int TrappingRainWaterBruteForce(int[] heights)
        {
            int totalWater = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                int maxLeft = 0;
                int maxRight = 0;
                for (int j = i; j >= 0; j--)
                {
                    maxLeft = Math.Max(maxLeft, heights[j]);
                }
                for (int j = i; j < heights.Length; j++)
                {
                    maxRight = Math.Max(maxRight, heights[j]);
                }
                totalWater += Math.Min(maxLeft, maxRight) - heights[i];
            }
            return totalWater;
        }

        public static int TrappingRainWater(int[] heights)
        {
            int pLeft = 0;
            int pRight = heights.Length - 1;
            int maxLeft = 0;
            int maxRight = 0;
            int totalWater = 0;

            while (pLeft < pRight)
            {
                if (heights[pLeft] < heights[pRight])
                {
                    if (maxLeft > heights[pLeft])
                    {
                        totalWater += maxLeft - heights[pLeft];
                    }
                    else
                    {
                        maxLeft = heights[pLeft];
                    }

                    pLeft++;
                }
                else
                {
                    if (maxRight > heights[pRight])
                    {
                        totalWater += maxRight - heights[pRight];
                    }
                    else
                    {
                        maxRight = heights[pRight];
                    }

                    pRight--;
                }
            }

            return totalWater;         
        }
        #endregion

        #region LargestAreaHistogram
        public static int LargestAreaHistogramBruteForce(int[] heights)
        {
            int maxArea = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = i; j < heights.Length; j++)
                {
                    var minHeight = int.MaxValue;
                    for (int k = i; k <= j; k++)
                    {
                        minHeight = Math.Min(minHeight, heights[k]);
                    }

                    maxArea = Math.Max(maxArea, minHeight * (j - i + 1));
                }
            }

            return maxArea;
        }

        public static int FindingLargestAreaHistogram(int[] heights)
        {
            var maxArea = 0;
            var extendedHeights = new int[heights.Length + 1];
            var stack = new Stack<int>();

            Array.Copy(heights, extendedHeights, heights.Length);

            for (int i = 0; i < extendedHeights.Length; i++)
            {
                while (stack.Count > 0 && extendedHeights[stack.Peek()] > extendedHeights[i])
                {
                    int top = stack.Pop();
                    int width = stack.Count == 0 ? i : i - stack.Peek() - 1;
                    int area = extendedHeights[top] * width;
                    maxArea = Math.Max(maxArea, area);
                }

                stack.Push(i);
            }

            return maxArea;
        }

        #endregion
    }


    [TestFixture]
    public class LeetCodeExercises1Tests
    {
        #region TwoSum
        [Test]
        public void TwoSumTestBruteForce()
        {
            var nums = new int[] { 15, 7, 11, 2 };
            var target = 9;
            var result = LeetCodeExercises1.TwoSumBruteForce(nums, target);

            Assert.That(result.Contains(7), Is.True);
            Assert.That(result.Contains(2), Is.True);
        }

        [Test]
        public void TwoSumTest()
        {
            var nums = new int[] { 15, 7, 11, 2 };
            var target = 9;
            var result = LeetCodeExercises1.TwoSum(nums, target);

            Assert.That(result.Contains(7), Is.True);
            Assert.That(result.Contains(2), Is.True);
        }
        #endregion

        #region ContainerWithMostWater
        [Test]
        public void ContainerWithMostWaterBruteForceTest()
        {
            var nums = new int[] { 7, 1, 2, 3, 9 };
            var result = LeetCodeExercises1.ContainerWithMostWaterBruteForce(nums);

            Assert.That(result.Equals(28), Is.True);
        }

        [Test]
        public void ContainerWithMostWaterBruteForceTestZero()
        {
            var nums = new int[] { 7 };
            var result = LeetCodeExercises1.ContainerWithMostWaterBruteForce(nums);

            Assert.That(result.Equals(0), Is.True);
        }

        [Test]
        public void ContainerWithMostWaterTest()
        {
            var nums = new int[] { 7, 1, 2, 3, 9 };
            var result = LeetCodeExercises1.ContainerWithMostWater(nums);

            Assert.That(result.Equals(28), Is.True);
        }

        [Test]
        public void ContainerWithMostWaterTest2()
        {
            var nums = new int[] { 4, 8, 1, 2, 3, 9 };
            var result = LeetCodeExercises1.ContainerWithMostWater(nums);

            Assert.That(result.Equals(32), Is.True);
        }

        [Test]
        public void ContainerWithMostWaterTestZero()
        {
            var nums = new int[] { 7 };
            var result = LeetCodeExercises1.ContainerWithMostWater(nums);

            Assert.That(result.Equals(0), Is.True);
        }
        #endregion

        #region ShiftingLinkedList
        [Test]
        public void ShiftLinkedListTestShiftRight()
        {
            var head = new Node(1);
            head.Next = new Node(2);
            head.Next.Next = new Node(3);
            head.Next.Next.Next = new Node(4);
            head.Next.Next.Next.Next = new Node(5);

            Node shiftedHead = LeetCodeExercises1.ShiftingLinkedList(head, 2);

            Assert.That(shiftedHead != null, Is.True);
            Assert.That(shiftedHead.Value, Is.EqualTo(4));
            Assert.That(shiftedHead.Next.Value, Is.EqualTo(5));
            Assert.That(shiftedHead.Next.Next.Value, Is.EqualTo(1));
            Assert.That(shiftedHead.Next.Next.Next.Value, Is.EqualTo(2));
            Assert.That(shiftedHead.Next.Next.Next.Next.Value, Is.EqualTo(3));
            Assert.That(shiftedHead.Next.Next.Next.Next.Next, Is.Null);
        }

        [Test]
        public void ShiftLinkedListTestShiftLeft()
        {
            var head = new Node(1);
            head.Next = new Node(2);
            head.Next.Next = new Node(3);
            head.Next.Next.Next = new Node(4);
            head.Next.Next.Next.Next = new Node(5);

            Node shiftedHead = LeetCodeExercises1.ShiftingLinkedList(head, -2);

            Assert.That(shiftedHead != null, Is.True);
            Assert.That(shiftedHead.Value, Is.EqualTo(3));
            Assert.That(shiftedHead.Next.Value, Is.EqualTo(4));
            Assert.That(shiftedHead.Next.Next.Value, Is.EqualTo(5));
            Assert.That(shiftedHead.Next.Next.Next.Value, Is.EqualTo(1));
            Assert.That(shiftedHead.Next.Next.Next.Next.Value, Is.EqualTo(2));
            Assert.That(shiftedHead.Next.Next.Next.Next.Next, Is.Null);
        }

        [Test]
        public void ShiftLinkedListTestShiftFullCircle()
        {
            var head = new Node(1);
            head.Next = new Node(2);
            head.Next.Next = new Node(3);
            head.Next.Next.Next = new Node(4);
            head.Next.Next.Next.Next = new Node(5);

            Node shiftedHead = LeetCodeExercises1.ShiftingLinkedList(head, 5);

            Assert.That(shiftedHead != null, Is.True);
            Assert.That(shiftedHead.Value, Is.EqualTo(1));
            Assert.That(shiftedHead.Next.Value, Is.EqualTo(2));
            Assert.That(shiftedHead.Next.Next.Value, Is.EqualTo(3));
            Assert.That(shiftedHead.Next.Next.Next.Value, Is.EqualTo(4));
            Assert.That(shiftedHead.Next.Next.Next.Next.Value, Is.EqualTo(5));
            Assert.That(shiftedHead.Next.Next.Next.Next.Next, Is.Null);
        }
        #endregion

        #region TrappingRainWater
        [Test]
        public void TrappingRainWaterBruteForceTest_1()
        {
            var heights = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var result = LeetCodeExercises1.TrappingRainWaterBruteForce(heights);
            Assert.That(result.Equals(6), Is.True);
        }

        [Test]
        public void TrappingRainWaterBruteForceTest_2()
        {
            var heights = new int[] { 0, 1, 0, 2, 1, 0, 3, 1, 0, 1, 2 };
            var result = LeetCodeExercises1.TrappingRainWaterBruteForce(heights);
            Assert.That(result.Equals(8), Is.True);
        }

        [Test]
        public void TrappingRainWaterBruteForceTest_zero()
        {
            var heights = new int[] { 0, 1, 0 };
            var result = LeetCodeExercises1.TrappingRainWaterBruteForce(heights);
            Assert.That(result.Equals(0), Is.True);
        }

        [Test]
        public void TrappingRainWaterTest_1()
        {
            var heights = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            var result = LeetCodeExercises1.TrappingRainWater(heights);
            Assert.That(result.Equals(6), Is.True);
        }

        [Test]
        public void TrappingRainWaterTest_2()
        {
            var heights = new int[] { 0, 1, 0, 2, 1, 0, 3, 1, 0, 1, 2 };
            var result = LeetCodeExercises1.TrappingRainWater(heights);
            Assert.That(result.Equals(8), Is.True);
        }

        [Test]
        public void TrappingRainWaterTest_zero()
        {
            var heights = new int[] { 0, 1, 0 };
            var result = LeetCodeExercises1.TrappingRainWater(heights);
            Assert.That(result.Equals(0), Is.True);
        }

        #endregion

        #region LargestAreaHistogram
        [Test]
        public void FindingLargestAreaHistogramBruteForceTest_1()
        {
            var heights = new int[] { 2, 1, 5, 6, 2, 3 };
            var result = LeetCodeExercises1.LargestAreaHistogramBruteForce(heights);
            Assert.That(result.Equals(10), Is.True);
        }

        [Test]
        public void FindingLargestAreaHistogramTest_1()
        {
            var heights = new int[] { 2, 1, 5, 6, 2, 3 };
            var result = LeetCodeExercises1.FindingLargestAreaHistogram(heights);
            Assert.That(result.Equals(10), Is.True);
        }
        #endregion
    }
}
