namespace Snake
{
    /// <summary>
    /// Represents the in-game snake, which traverses the 2D array of Positions.
    /// </summary>
    public class Snake
    {
        private Queue<Position> body;
        private int n;
        private int capacity;
        private Position[][] grid;
        private bool Collided;

        public Snake(Position[][] grid, int capacity)
        {
            this.grid = grid;
            this.capacity = capacity;
            n = 0;
            Collided = false;
            body = new Queue<Position>();
        }



        public bool Move()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            int x = 1;
            int y = grid.Length / 2;
            int direction = 0;
            int previousDirection = 0;
            bool headChangedDirection = false; // Flag to keep track of whether the head has changed direction

            // Keep track of the last position of the snake's tail
            Position last = null;

            while (!Collided && x < grid[0].Length - 1 && y < grid.Length - 1 && x > 0 && y > 0)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (previousDirection != 3) // Only change direction if not going down
                            {
                                direction = 1;
                                headChangedDirection = true;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (previousDirection != 0) // Only change direction if not going right
                            {
                                direction = 2;
                                headChangedDirection = true;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (previousDirection != 1) // Only change direction if not going up
                            {
                                direction = 3;
                                headChangedDirection = true;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (previousDirection != 2) // Only change direction if not going left
                            {
                                direction = 0;
                                headChangedDirection = true;
                            }
                            break;
                    }
                }

                switch (direction)
                {
                    case 0: // move right
                        x++;
                        break;
                    case 1: // move up
                        y--;
                        break;
                    case 2: // move left
                        x--;
                        break;
                    case 3: // move down
                        y++;
                        break;
                }

                if (grid[y][x].SnakeKiller)
                {
                    Console.SetCursorPosition(grid[0][0].X1, grid[grid.Length - 1][0].Y + 1);
                    Console.ForegroundColor = ConsoleColor.White;
                    return false;
                }

                // Add new position to front of body
                body.Enqueue(grid[y][x]);
                grid[y][x].Snake = true;

                // If length exceeds capacity, remove last position from back of body
                if (body.Count > capacity)
                {
                    last = body.Dequeue();
                    last.Snake = false;
                }

                // If last is not null (i.e., the snake has moved at least once),
                // reset the last position to black
                if (last != null)
                {
                    last.Snake = false;
                    last.Draw(last == body.Last());
                }

                // Draw new head position
                if (headChangedDirection) // If the head changed direction, draw with the new color
                {
                    grid[y][x].Draw(true);
                    headChangedDirection = false; // Reset the flag
                }
                else // Otherwise, draw with the previous color
                {
                    grid[y][x].Draw(false);
                }

                Thread.Sleep(150);
                previousDirection = direction; // Store the previous direction
            }

            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }




    }
}
