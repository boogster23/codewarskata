using NUnit.Framework;

namespace CodeKataConsole
{
    public static class SortingAlgorithms
    {
        public static List<int> InsertionSort(List<int> intList)
        {
            for (int i = 0; i < intList.Count; i++)
            {
                var current = i;
                
                while (current > 0 && intList[current] < intList[current - 1])
                {
                    var tempHolder = intList[current - 1];
                    intList[current - 1] = intList[current];
                    intList[current] = tempHolder;
                    current--;
                }
            }

            return intList;
        }

        public static List<int> SelectionSort(List<int> intList)
        {
            for (int i = 0; i < intList.Count; i++)
            {
                int minIndex = i;

                for (int j = i;  j < intList.Count; j++)
                {
                    if (intList[minIndex] > intList[j])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex == i)
                {
                    continue;
                }

                var tempHolder = intList[i];
                intList[i] = intList[minIndex];
                intList[minIndex] = tempHolder;                
            }

            return intList;
        }

        public static List<int> BubbleSort(List<int> intList)
        {
            var n = intList.Count;
            for (int i = n - 1; i >= 0; i--)
            {
                var swapped = false;
                for (int j = 0; j < i; j++)
                {
                    if (intList[j] > intList[j + 1])
                    {
                        var temp = intList[j];
                        intList[j] = intList[j + 1];
                        intList[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped) return intList;
            }
            return intList;
        }

        public static List<int> MergeSort(List<int> intList)
        {
            return MergeSortInterval(intList, 0, intList.Count);
        }

        private static List<int> MergeSortInterval(List<int> intList, int start, int end)
        {
            if (end - start <= 1)
            {
                return intList.GetRange(start,  end - start);
            }

            int mid = (start + end) / 2;
            var leftList = MergeSortInterval(intList, start, mid);
            var rightList = MergeSortInterval(intList, mid, end);
            var sortedList = new List<int>();
            var leftPointer = 0;
            var rightPointer = 0;

            while (leftPointer < leftList.Count || rightPointer < rightList.Count)
            {
                if (leftPointer == leftList.Count)
                {
                    sortedList.Add(rightList[rightPointer]);
                    rightPointer++;
                }
                else if (rightPointer == rightList.Count ||
                         leftList[leftPointer] <= rightList[rightPointer])
                {
                    sortedList.Add(leftList[leftPointer]);
                    leftPointer++;
                }
                else
                {
                    sortedList.Add(rightList[rightPointer]);
                    rightPointer++;
                }
            }

            return sortedList;
        }

        public static List<int> QuickSort(List<int> intList)
        {
            return QuickSortInterval(intList, 0, intList.Count);
        }

        private static List<int> QuickSortInterval(List<int> intList, int start, int end)
        {
            if (end - start <= 1)
            {
                return intList.GetRange(start, end - start);
            }

            var startPtr = start;
            var endPtr = end - 1;
            var pivot = intList[endPtr];
            int temp;

            while (startPtr < endPtr)
            {
                while (intList[startPtr] < pivot && startPtr < endPtr)
                {
                    startPtr++;
                }
                while (intList[endPtr] >= pivot && startPtr < endPtr)
                {
                    endPtr--;
                }

                if (startPtr == endPtr)
                {
                    break;
                }

                temp = intList[startPtr];
                intList[startPtr] = intList[endPtr];
                intList[endPtr] = temp;
            }

            temp = intList[startPtr];
            intList[startPtr] = intList[end - 1];
            intList[end - 1] = temp;

            QuickSortInterval(intList, start, startPtr);
            QuickSortInterval(intList, startPtr + 1, end);

            return intList;
        }
    }

    [TestFixture]
    public class SortingAlgorithmsTests
    {
        List<int> unsortedList = [4, 6, 8, 10, 5, 2, 7, 1, 3, 9];
        List<int> expectedSortedList = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

        [Test]
        public void InsertionSortTests()
        {
            var sortedList = SortingAlgorithms.InsertionSort(unsortedList);
            Assert.That(sortedList, Is.EquivalentTo(expectedSortedList));
        }

        [Test]
        public void SelectionSortTests()
        {
            var sortedList = SortingAlgorithms.SelectionSort(unsortedList);
            Assert.That(sortedList, Is.EquivalentTo(expectedSortedList));
        }

        [Test]
        public void BubbleSortTests()
        {
            var sortedList = SortingAlgorithms.BubbleSort(unsortedList);
            Assert.That(sortedList, Is.EquivalentTo(expectedSortedList));
        }

        [Test]
        public void MergeSortTests()
        {
            var sortedList = SortingAlgorithms.MergeSort(unsortedList);
            Assert.That(sortedList, Is.EquivalentTo(expectedSortedList));
        }

        [Test]
        public void QuickSortTests()
        {
            var sortedList = SortingAlgorithms.QuickSort(unsortedList);
            Assert.That(sortedList, Is.EquivalentTo(expectedSortedList));
        }
    }
}
