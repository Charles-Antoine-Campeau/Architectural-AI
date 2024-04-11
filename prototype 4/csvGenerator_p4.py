"""
Generate random rooms and place them in a csv file
"""
import os
import random
import time
import csv

# set the working directory to the script location
abspath = os.path.abspath(__file__)
dname = os.path.dirname(abspath)
os.chdir(dname)

numberOfRoom = int(input("number of rooms: "))

roomList = []
offsets = ["north", "south", "east", "west"]

for i in range(numberOfRoom):
    name = f"room{i}"
    x = random.randint(2, 12)
    y = random.randint(2, 12)
    shape = "rectangle"
    offset = random.choice(offsets)
    exteriorExit = random.choice([True, False])

    roomList.append((name, x, y, shape, offset, exteriorExit))

currentTime = str(time.time())
currentTime = currentTime.split(".", 1)[0]

with open(f"house{currentTime}.csv", 'w', newline='') as myfile:
     writer = csv.writer(myfile)
     for row in roomList:
        writer.writerow(row)
    