using static Raylib_cs.Raylib;
using Color = Raylib_cs.Color;
using Raylib_cs;
using System.Numerics;

namespace Prototype2
{
     class PlanDrawer
    {
        public PlanDrawer(RoomList roomList)
        {
            // main iterator for the room list
            RoomList.Iterator? roomIterator = new RoomList.Iterator(roomList);

            // initialize the screen and framerate
            const int screenWidth = 1400;
            const int screenHeight = 900;
            InitWindow(screenWidth, screenHeight, "Prototype 2");
            SetTargetFPS(60);

            // get the first room of the list and set its position
            var anchor = roomIterator.GetCurrent();
            anchor.Setcenter( new Vector2(screenWidth / 2, screenHeight / 2) );
            anchor.Setspeed(new Vector2(0, 0));

            // get the room that is currently being worked on
            var current = anchor;

            House house = new(anchor.GetxSize(), anchor.GetySize(), anchor.GetCenter());

            // Main game loop
            while (!WindowShouldClose())
            {
                // ******************** UPDATE PHASE ********************

                if (current.GetSpeed() == Vector2.Zero && roomIterator.HasNext()) // a room that does not have a speed has been placed
                {
                    RoomList.Iterator setHouseSizeIterator = new RoomList.Iterator(roomList);
                    RoomList.RoomNode placedRoom = setHouseSizeIterator.GetCurrent();

                    int xMin = screenWidth / 2;
                    int xMax = screenWidth/2;
                    int yMin = screenHeight / 2;
                    int yMax = screenHeight/2;

                    while (placedRoom.GetSpeed() == Vector2.Zero)
                    {
                        // get the absolute position of the room
                        int tmpXMin = (int)placedRoom.GetCenter().X - placedRoom.GetxSize() / 2;
                        int tmpXMax = (int)placedRoom.GetCenter().X + placedRoom.GetxSize() / 2;
                        int tmpYMin = (int)placedRoom.GetCenter().Y - placedRoom.GetySize() / 2;
                        int tmpYMax = (int)placedRoom.GetCenter().Y + placedRoom.GetySize() / 2;

                        // compare to see which direction the house expanded
                        if (tmpXMin < xMin) { xMin = tmpXMin; }
                        if (tmpXMax > xMax) {  xMax = tmpXMax; }
                        if (tmpYMin < yMin) {  yMin = tmpYMin; }
                        if (tmpYMax > yMax) {  yMax = tmpYMax; }

                        placedRoom = setHouseSizeIterator.GetNext();
                    }

                    // set the house's new parameters
                    house.SetSizeX(xMax - xMin);
                    house.SetSizeY(yMax - yMin);
                    house.SetCenter(new Vector2(
                        xMax - (xMax-xMin)/2,
                        yMax - (yMax-yMin)/2
                        ));


                    // get the next room to place
                    current = roomIterator.GetNext();

                    // set the initial position based on the given position
                    switch (current.Getposition())
                    {
                        case RoomList.Position.NORTH:
                            current.Setcenter(new Vector2(screenWidth / 2, 100));
                            break;
                        case RoomList.Position.SOUTH:
                            current.Setcenter(new Vector2(screenWidth/2, screenHeight-100));
                            break;
                        case RoomList.Position.EAST:
                            current.Setcenter(new Vector2(screenWidth-100, screenHeight / 2));
                            break;
                        case RoomList.Position.WEST:
                            current.Setcenter(new Vector2(100, screenHeight / 2));
                            break;
                        default:
                            break;
                    }
                }

                MoveTowardsHouse(current, house);
                current.Setcenter(current.GetCenter() + current.GetSpeed());


                // ******************** DRAWING PHASE ********************
                BeginDrawing();
                ClearBackground(Color.RAYWHITE);

                // Draw the anchor
                DrawRectangleV(
                    anchor.GetCenter() + new Vector2(-anchor.GetxSize()/2, -anchor.GetySize()/2),
                    new Vector2(anchor.GetxSize(), anchor.GetySize()),
                    Color.RED
                    );

                // iterator to draw the list
                var drawingIterator = new RoomList.Iterator(roomList);
                var draw = drawingIterator.GetNext();

                // draw every room from the one after the anchor to the one currently being worked on
                while (draw != current.GetNext())
                {
                    DrawRectangleV(
                        draw.GetCenter() + new Vector2(-draw.GetxSize() / 2, -draw.GetySize() / 2),
                        new Vector2(draw.GetxSize(), draw.GetySize()),
                        Color.GREEN
                        );
                    draw = draw.GetNext();
                }

                //draw the house boundaries
                DrawRectangleLines(
                    (int)house.GetCenter().X - house.GetSizeX()/2,
                    (int)house.GetCenter().Y - house.GetSizeY()/2,
                    house.GetSizeX(),
                    house.GetSizeY(),
                    Color.BLUE
                    );

                EndDrawing();
            }

            CloseWindow();
        }

        private void MoveTowardsHouse(RoomList.RoomNode current, House house)
        {
            Vector2 speed = new Vector2(0, 0);

            Vector2 difference = current.GetCenter() - house.GetCenter();

            if (difference.X == (current.GetxSize() + house.GetSizeX()) / 2) { speed.X = 0; }
            else if (difference.X > 0) { speed.X = -1; }
            else if(difference.X < 0) { speed.X = 1; }

            if (difference.Y == (current.GetySize() + house.GetSizeY()) / 2) { speed.Y = 0; }
            else if (difference.Y > 0) { speed.Y = -1; }
            else if (difference.Y < 0) { speed.Y = 1; }

            current.Setspeed(speed);
        }

        private class House
        {
            int sizeX;
            int sizeY;
            Vector2 center;

            public House(int sizeX, int sizeY, Vector2 center)
            {
                this.sizeX = sizeX;
                this.sizeY = sizeY;
                this.center = center;
            }

            public int GetSizeX() { return sizeX; }
            public int GetSizeY() { return sizeY; }
            public Vector2 GetCenter() { return center; }

            public void SetSizeX(int sizeX) { this.sizeX = sizeX; }
            public void SetSizeY(int sizeY) { this.sizeY = sizeY; }
            public void SetCenter(Vector2 center) { this.center = center; }
        }
    }
}
