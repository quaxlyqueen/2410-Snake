namespace Snake
{
    /// 
    /// <summary>Represents a Console position in Left and Top coordinates, AKA (x, y).</summary>
    ///
    /// <author>Josh Ashton</author>
    ///
    public class Position
    {
        public int X1;
        public int X2;
        public int Y { get; }

        private const ConsoleColor D_GREEN = ConsoleColor.DarkGreen;
        private const ConsoleColor BLACK = ConsoleColor.Black;
        private const ConsoleColor GREEN = ConsoleColor.Green;
        private const ConsoleColor WHITE = ConsoleColor.White;


        public bool SnakeKiller { get; }
        public int SnakeHead { get; set; }
        public Position Next { get; set; }
        public Position Prev { get; set; }

        public Position(int x1, int x2, int y)
        {
            X1 = x1;
            X2 = x2;
            Y = y;
        }

        public Position(int x1, int x2, int y, bool snakeKiller)
        {
            X1 = x1;
            X2 = x2;
            Y = y;
            SnakeKiller = snakeKiller;
            SnakeHead = -1;
        }
        
        public Position(int x1, int x2, int y, bool snakeKiller, int snakeHead)
        {
            X1 = x1;
            X2 = x2;
            Y = y;
            SnakeKiller = snakeKiller;
            SnakeHead = snakeHead;
        }

        public void Draw() {
            if(SnakeKiller)
            {
                Console.BackgroundColor = D_GREEN;
                Console.Write("  ");
                Console.BackgroundColor = BLACK;
            } 
            else if (SnakeHead == 1)
            {
                Console.BackgroundColor = WHITE;
                Console.Write("  ");
                Console.BackgroundColor = BLACK;
            } 
            else if (SnakeHead == 0)
            {
                Console.BackgroundColor = GREEN;
                Console.Write("  ");
                Console.BackgroundColor = BLACK;
            }
            else if(SnakeHead == -1)
            {
                Console.Write("  ");
            }
        }
    }
}