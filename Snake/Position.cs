namespace Snake
{
    /// 
    /// <summary>Represents a Console position in Left and Top coordinates, AKA (x, y).</summary>
    ///
    /// <author>Josh Ashton</author>
    ///
    public class Position
    {
        public int x1;
        public int x2;
        public int y { get; set; }
        public int vMargin { get; set; }
        public int wMargin { get; set; }
        
        private const ConsoleColor GREEN = ConsoleColor.Green;
        private const ConsoleColor BLACK = ConsoleColor.Black;
        
        public bool snakeKiller { get; }

        public Position(int x1, int x2, int y, bool snakeKiller)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y = y;
            this.snakeKiller = snakeKiller;
        }

        public void Draw() {
            Console.SetCursorPosition(x1, y);
            if(snakeKiller)
            {
                Console.BackgroundColor = GREEN;
                Console.Write("  ");
                Console.BackgroundColor = BLACK;
            }
            else
            {
                Console.Write("  ");
            }
        }
    }
}