

using System.Numerics;

namespace Prototype2
{
    /// <summary>
    /// Implementation of a List that uses nodes to store the description of different rooms.
    /// </summary>
    class RoomList
    {

        public enum Position
        {
             NORTH,
            SOUTH,
            EAST,
            WEST
        }

        public enum Shape
        {
            RECTANGLE
        }

        // parameters
        private  RoomNode? first;
        private RoomNode? last;

        // constructor
        public RoomList()
        {
            first = null;
            last = null;
        }

        /// <summary>
        /// Get the first element of the list
        /// </summary>
        /// <returns>the first element of the list</returns>
        private RoomNode? GetFirst() { return first; }


        /// <summary>
        /// Create a new room and add it at the end of the list
        /// </summary>
        /// <param name="name">The name of the room</param>
        /// <param name="dimensions">An array with the necessary dimensions</param>
        /// <param name="shape">The shape of the room</param>
        /// <param name="position">he side the room should come from</param>
        public void AddRoom(string name, int[] dimensions, Shape shape, Position position)
        {
            // a switch case for every shape
            switch (shape)
            {
                case Shape.RECTANGLE:  // add a rectangle room
                    NewRectangleRoom(name, dimensions[0], dimensions[1], position); break;
                default: break;
            }
        }

        /// <summary>
        /// Create a new node for a rectangular room and add it at the end of the list
        /// </summary>
        /// <param name="name">The name of the room</param>
        /// <param name="xSize">The X dimension of the room</param>
        /// <param name="ySize">The Y dimension of the room</param>
        /// <param name="position">The side the room should come from</param>
        private void NewRectangleRoom(string name, int xSize, int ySize, Position position)
        {
            if (first == null) // if the list is empty
            {
                first = last = new RoomNode(name, xSize, ySize, position, null, null);
            }
            else if (first == last) // if there is 1 element in the list
            {
                last = new RoomNode(name, xSize, ySize, position, first, null);
                first.Setnext(last);
            }
            else // if there are multiple elements in the list
            {
                RoomNode newRoom = new(name, xSize, ySize, position, last, null);
                last.Setnext(newRoom);
                last = newRoom;
            }
        }

        /// <summary>
        /// Object to iterate over a given RoomList
        /// </summary>
        public class Iterator
        {
            // variables
            private readonly RoomList list;
            private RoomNode? current;

            // constructor
            public Iterator(RoomList list)
            {
                this.list = list;
                current = list.GetFirst();
            }

            /// <summary>
            /// Check if there is another node after the current one
            /// </summary>
            /// <returns> <c>true</c> if there is another node, <c>false</c> otherwise</returns>
            public bool HasNext()
            {
                if (current.GetNext() == null) { return false; }
                else { return true; }
            }

            /// <summary>
            /// Get the node the iterator is currently pointing to
            /// </summary>
            /// <returns>The current <c>RoomNode</c></returns>
            public RoomNode? GetCurrent() { return current; }

            /// <summary>
            /// Get the next node and set is as the current one
            /// </summary>
            /// <returns>The new current node</returns>
            public RoomNode? GetNext()
            {
                current = current.GetNext();
                return current;
            }

            /// <summary>
            /// Set the iterator back to the first node
            /// </summary>
            public void Restart()
            {
                while (current.GetPrevious() != null)
                {
                    current = current.GetPrevious();
                }
            }
        }

        /// <summary>
        /// Implementation of a node to store the description of a room
        /// </summary>
        public class RoomNode
        {
            // variables
            private readonly string name;
            private int xSize;
            private int ySize;
            private Position position;
            private RoomNode? previous;
            private RoomNode? next;
            private Vector2 center;
            private Vector2 speed;

            // constructor
            public RoomNode(string name, int xSize, int ySize, Position position, RoomNode? previous, RoomNode? next)
            {
                this.name = name;
                this.xSize = xSize;
                this.ySize = ySize;
                this.position = position;
                this.previous = previous;
                this.next = next;
                center = new Vector2(0,0);
                speed = new Vector2(1,1);
            }

            // getters
            public string GetName() {  return name; }
            public int GetxSize() { return xSize; }
            public int GetySize() {  return ySize; }
            public Position Getposition() { return position; }
            public RoomNode? GetPrevious() { return previous; }
            public RoomNode? GetNext() {  return next; }
            public Vector2 GetCenter() { return center; }
            public Vector2 GetSpeed() { return speed; }

            // setters
            public void SetxSize(int size) { xSize = size; }
            public void SetySize(int size) {  ySize = size; }
            public void Setposition(Position position) {  this.position = position; }
            public void Setprevious(RoomNode? previous) {  this.previous = previous; }
            public void Setnext(RoomNode? next) {  this.next = next; }
            public void Setcenter(Vector2 center) {  this.center = center; }
            public void Setspeed(Vector2 speed) {  this.speed = speed; }
        }
    }
}
