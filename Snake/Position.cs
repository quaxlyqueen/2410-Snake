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

        private const ConsoleColor D_GREEN = ConsoleColor.DarkGreen;
        private const ConsoleColor BLACK = ConsoleColor.Black;
        private const ConsoleColor GREEN = ConsoleColor.Green;

        public bool snakeKiller { get; }
        public bool snake { get; set; }
        public bool head { get; set; }

        public Position(int x1, int x2, int y, bool snakeKiller)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y = y;
            this.snakeKiller = snakeKiller;
        }
        
        public Position(int x1, int x2, int y, bool snakeKiller, int vertMargin, int horMargin)
        {
            this.x1 = x1 + horMargin;
            this.x2 = x2 + horMargin;
            this.y = y + vertMargin;
            this.snakeKiller = snakeKiller;
        }
        
        public Position(int x1, int x2, int y, bool snake, bool head, int vertMargin, int horMargin)
        {
            this.x1 = x1 + horMargin;
            this.x2 = x2 + horMargin;
            this.y = y + vertMargin;
            this.snake = snake;
            this.head = head;
            this.snakeKiller = snakeKiller;
        }

        public void Draw() {
            Console.SetCursorPosition(x1, y);
            /*
            if (snake)
            {
                if (head)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = GREEN;
                }
                Console.Write("  ");
                Console.BackgroundColor = BLACK;
            } 
            else */if(snakeKiller)
            {
                Console.BackgroundColor = D_GREEN;
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