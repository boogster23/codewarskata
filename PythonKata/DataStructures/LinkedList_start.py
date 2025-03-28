class Node(object):
  def __init__(self, data):
    self.val = data
    self.next = None

  def get_data(self):
    return self.val
  
  def set_data(self, data):
    self.val = data

  def get_next(self):
    return self.next
  
  def set_next(self, next_node):
    self.next = next_node

class LinkedList(object):
  def __init__(self):
    self.head = None
    self.tail = None
    self.count = 0

  def get_count(self):
    return self.count
  
  def insert(self, data):
    new_node = Node(data)
    new_node.set_next(self.head)
    self.head = new_node
    self.count += 1

  def find(self, val):
    item = self.head
    while item != None:
      if item.get_data() == val:
          return item
      item = item.get_next()

    return None

  def deleteAt(self, idx):
    if idx > self.count - 1:
      return 
      
    if idx == 0:
        self.head = self.head.get_next()
        self.count -= 1
    else:
        tempIdx = 0
        node = self.head
        while tempIdx < idx - 1:
            node = node.get_next()
            tempIdx += 1

        node.set_next(node.get_next().get_next())
        self.count -= 1

      
  def dump_list(self):
    item = self.head
    while item != None:
      print("Node: ", item.get_data())
      item = item.get_next()

itemList = LinkedList()
itemList.insert(38)
itemList.insert(49) 
itemList.insert(13)
itemList.insert(15)
itemList.dump_list()

# print("Item count: ", itemList.get_count())
# print("Find 38: ", itemList.find(38))
# print("Find 100: ", itemList.find(100))


#delete an item
print("Item count: ", itemList.get_count())
itemList.deleteAt(3)
print("Item count: ", itemList.get_count())
print("Finding 38: ", itemList.find(38))
itemList.dump_list()