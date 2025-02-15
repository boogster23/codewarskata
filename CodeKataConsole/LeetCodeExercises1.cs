using NUnit.Framework;

namespace CodeKataConsole
{
    public class LeetCodeExercises1
    {
        public static int[]? TwoSum(int[] nums, int target)
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

            return null;
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

            Assert.That(result != null, Is.True);
            Assert.That(result.Contains(7), Is.True);
            Assert.That(result.Contains(2), Is.True);
        }
    }
}
