# Queue implementation using collections.deque
from collections import deque

queue = deque()

queue.append(1)
queue.append(2)
queue.append(3)
queue.append(4)

print("Queue: ", queue)

x = queue.popleft()
print("Dequeued: ", x)

y = queue.pop()
print("Popped: ", y)

print("Queue: ", queue)
print("Queue size: ", len(queue))