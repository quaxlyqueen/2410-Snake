namespace Snake
{
    /// <summary>
    /// Represents the in-game snake, which traverses the 2D array of Positions.
    /// </summary>
    public class Snake
    {
        private Position head;
        private Position tail;
        private int capacity;
        private int size;
        private Position[][] grid;

        public Snake(Position start, Position[][] grid, int capacity)
        {
            this.grid = grid;
            this.capacity = capacity;
            head = start;
            size = 0;
        }

        /// <summary>
        /// Provide a direction for the snake to move towards. Each move checks if the new head slot is an obstacle.
        /// 0 = right, 1 = up, 2 = left, 3 = down
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>true if nextPosition is a non obstacle.</returns>
        public bool Move(int direction)
        {
            Position p = null;
            switch (direction)
            {
                case 1: // move up
                    p = new Position(head.X1 + 2, head.X2 + 2, head.Y + 0, false, 1);
                    break;
                case 2: // move left
                    p = new Position(head.X1 + 0, head.X2 + 0, head.Y + 0, false, 1);
                    break;
                case 3: // move down
                    p = new Position(head.X1 + 0, head.X2 + 0, head.Y + 0, false, 1);
                    break;
                default: // move right
                    p = new Position(head.X1 + 2, head.X2 + 2, head.Y + 0, false, 1);
                    break;
            }

            if (p != null)
            {
                //remove();
                add(p);
                draw();
                return true;
            }
            return false;
        }

        public void draw() {
            Position current = head;
            while (current != null)
            {
                Console.SetCursorPosition(current.X1, current.Y);
                current.Draw();
                current = current.Next;
            }
        }
        
        // TODO: Need to implement.
        private void add(Position p)
        {
            if (size == capacity)
                throw new OutOfMemoryException("Must remove an snake segment first.");

            head.Next = p;
            head.Next.Prev = head;
            head = p;
            head.Prev.SnakeHead = 0;
        }

        // TODO: Need to implement.
        private void remove()
        {

        }
    }
}