namespace Snake
{
    /// <summary>
    /// Represents the in-game snake, which traverses the 2D array of Positions.
    /// </summary>
    public class Snake
    {
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
        }

        public bool Move()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            int x = 1;
            int y = grid.Length / 2;
            int direction = 0;

            while (!Collided && x < grid[0].Length - 1 && y < grid.Length - 1 && x > 0 && y > 0)
            {
                if (Console.KeyAvailable)
                {
                    char d = Console.ReadKey().KeyChar;
                    switch (d)
                    {
                        case 'w':
                            direction = 1;
                            break;
                        case 'a':
                            direction = 2;
                            break;
                        case 's':
                            direction = 3;
                            break;
                        case 'd':
                            direction = 0;
                            break;
                    }
                }
                Console.SetCursorPosition(grid[y][x].X1, grid[y][x].Y);
                grid[y][x].Draw(false);
                switch (direction)
                {
                    case 0: // move right
                        x++;
                        grid[y][x].Snake = true;
                        break;
                    case 1: // move up
                        y--;
                        grid[y][x].Snake = true;
                        break;
                    case 2: // move left
                        x--;
                        grid[y][x].Snake = true;
                        break;
                    case 3: // move down
                        y++;
                        grid[y][x].Snake = true;
                        break;
                }
                Console.SetCursorPosition(grid[y][x].X1, grid[y][x].Y);
                grid[y][x].Draw(false);
                Thread.Sleep(200);
            }
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }
    }
}