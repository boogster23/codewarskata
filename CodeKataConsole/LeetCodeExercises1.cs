using NUnit.Framework;

namespace CodeKataConsole
{
    public class LeetCodeExercises1
    {
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
            int a = 0;
            int b = nums.Length - 1;

            while (b > a)
            {
                var height = Math.Min(nums[a], nums[b]);
                var width = b - a;
                var currentArea = height * width;
                maxArea = Math.Max(currentArea, maxArea);

                if (nums[a] <= nums[b])
                {
                    a++;
                }
                else
                {
                    b--;
                }
            }

            return maxArea;
        }
    }


    [TestFixture]
    public class LeetCodeExercises1Tests
    {
        [Test]
        public void TwoSumTest()
        {
            var nums = new int[] { 15, 7, 11, 2 };
            var target = 9;
            var result = LeetCodeExercises1.TwoSum(nums, target);

            Assert.That(result.Contains(7), Is.True);
            Assert.That(result.Contains(2), Is.True);
        }

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
    }
}
