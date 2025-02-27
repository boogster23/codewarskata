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

        public static bool HasMatchingParenthesisStacks(string s)
        {
            var stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(s[i]);
                }
                
                if (s[i] == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }

        public static bool LinkedListHasCycleUsingHashSets(Node head)
        {
            if (head == null)
            {
                return false;
            }

            var nodes = new HashSet<Node>();
            var current = head;

            while (current != null)
            {
                if (nodes.Contains(current))
                {
                    return true;
                }
                nodes.Add(current);
                current = current.Next;
            }

            return false;
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

        [Test]
        public void HasMatchingParenthesisStacksTest()
        {
            var testString = "((()))";

            Assert.That(BasicAlgorithms.HasMatchingParenthesisStacks(testString), Is.True);
        }

        [Test]
        public void HasMatchingParenthesisStacksFalseTest()
        {
            var testString = "(((asd";

            Assert.That(BasicAlgorithms.HasMatchingParenthesisStacks(testString), Is.False);
        }

        [Test]
        public void LinkedListHasCycleTest()
        {
            var head = new Node(1);
            head.Next = new Node(2);
            head.Next.Next = new Node(3);
            head.Next.Next.Next = new Node(4);
            head.Next.Next.Next.Next = head.Next;
            Assert.That(BasicAlgorithms.LinkedListHasCycleUsingHashSets(head), Is.True);
        }

        [Test]
        public void LinkedListHasCycleFalseTest()
        {
            var head = new Node(1);
            head.Next = new Node(2);
            head.Next.Next = new Node(3);
            head.Next.Next.Next = new Node(4);
            Assert.That(BasicAlgorithms.LinkedListHasCycleUsingHashSets(head), Is.False);
        }
    }
}