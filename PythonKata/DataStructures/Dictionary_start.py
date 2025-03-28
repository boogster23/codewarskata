items1 = dict({"key1": 1, "key2": 2, "key3": 3})
print("Items1: ", items1)

items2 = {}
items2["key1"] = 1
items2["key2"] = 2
items2["key3"] = 3
print("Items2: ", items2)

items2["key2"] = "two"
print("Items2: ", items2)

for key, value in items2.items():
    print("Key:", key, " Value:", value)