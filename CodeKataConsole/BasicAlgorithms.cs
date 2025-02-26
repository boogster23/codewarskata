using NUnit.Framework;

namespace CodeKataConsole
{
    public class BasicAlgorithms
    {
        public static void PrintBinary(int n)
        {
            if (n <= 0)
            {
                return;
            }

            var queue = new Queue<int>();
            queue.Enqueue(1);

            for (int i = 0; i < n; i++)
            {
                var current = queue.Dequeue();
                Console.WriteLine(current);
                queue.Enqueue(current * 10);
                queue.Enqueue(current * 10 + 1);
            }

            Console.WriteLine();
        }
    }

    [TestFixture]
    public class BasicAlgorithmsTests
    {
        [Test]
        public void PrintBinaryTest()
        {
            using (StringWriter sw = new())
            {
                Console.SetOut(sw);
                BasicAlgorithms.PrintBinary(5);
                var expectedOutput = "1\r\n10\r\n11\r\n100\r\n101\r\n\r\n";
                Assert.That(sw.ToString(), Is.EqualTo(expectedOutput));
            }
        }
    }
}