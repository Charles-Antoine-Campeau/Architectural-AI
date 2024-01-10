
import pandas as pd
import os
import turtle

SCALE = 10

#set the working directory to the script location
abspath = os.path.abspath(__file__)
dname = os.path.dirname(abspath)
os.chdir(dname)

#get the csv with the room and dimensions
rooms = pd.read_csv("rooms.csv")

skk = turtle.Turtle()

#loops through the rooms and draw the corresponding rectangle
for index, row in rooms.iterrows():
    for i in range(4):
        skk.forward(int(row[i%2+1])*SCALE)
        skk.right(90)
    skk.right(90)


turtle.done()