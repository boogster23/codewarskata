namespace CodeKataConsole
{
    public class KataTreeByLevels
    {
        public static List<int> TreeByLevels(Node node)
        {
            var sortedLevels = new List<int>();

            if (node == null)
                return sortedLevels;

            var currentLevelNodes = new List<Node>() { node };

            while (currentLevelNodes != null && currentLevelNodes.Count > 0)
            {
                var newLeveNodes = new List<Node>();

                foreach (var levelNode in currentLevelNodes)
                {
                    sortedLevels.Add(levelNode.Value);

                    if (levelNode.Left != null)
                        newLeveNodes.Add(levelNode.Left);

                    if (levelNode.Right != null)
                        newLeveNodes.Add(levelNode.Right);
                }

                currentLevelNodes = newLeveNodes;
            }

            return sortedLevels;
        }

        public static List<int> TreeByLevelsUsingQueue(Node node)
        {
            var result = new List<int>();

            if (node == null)
                return result;

            var queue = new Queue<Node>();
            queue.Enqueue(node);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                result.Add(currentNode.Value);

                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);

                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
            }

            return result;
        }
    }

    public class Node
    {
        public Node Left;
        public Node Right;
        public Node Next;
        public int Value;

        public Node(Node l, Node r, int v)
        {
            Left = l;
            Right = r;
            Value = v;
        }

        public Node(int value)
        {
            this.Value = value;
        }

    }
}
