using Snake;
using System;
namespace Snake
{
    /// 
    /// <summary>Represents the user-controlled snake.</summary>
    ///
    public class Snake
    {
        private Position p;
        private RingBuffer buffer;
        private int snakeLength;
        private int[][] board;

        ///
        /// <summary>Create a snake object with a length based on the provided complexity.</summary>
        ///
        public Snake(int complexity, int[][] board, Position p)
        {
            
            buffer = new RingBuffer();
            //buffer.Add(p);
            
            this.board = board;
            Create(p, complexity);
        }

        /**
         * 0 = default, move right
         * 1 = move up,
         * 2 = move left
         * 3 = move down
         */ 
        public void move(int direction)
        {
            // Need snake head position
            Position snakeHead = buffer.head.p;
            Position newP = null;
            switch(direction)
            {
                case 0:
                    newP = new Position(snakeHead.X + 2, snakeHead.Y);
                    break;
                case 1:
                    newP = new Position(snakeHead.X, snakeHead.Y - 1);
                    break;
                case 2:
                    newP = new Position(snakeHead.X - 2, snakeHead.Y);
                    break;
                case 3:
                    newP = new Position(snakeHead.X, snakeHead.Y + 1);
                    break;
            }
            if (board[newP.X - 1][newP.Y] != 1 || board[newP.X][newP.Y] != 1)
            {
                buffer.Add(newP);
                //buffer.Remove();
                buffer.Draw(ConsoleColor.White);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Game over.");
                Console.WriteLine($"newP.X: {newP.X}, newP.Y: {newP.Y}");
                //Console.WriteLine($"value at position: 0, 0 = {board[0][0]}");

                Environment.Exit(0);

            }

        }

        /// 
        /// <summary>Fill the RingBuffer with the position of each segment of the snake, starting with
        /// a provided Position, and moving down and left.</summary>
        ///
        public void Create(Position start, int c)
        {
            buffer.Add(start);
            for (int i = 0; i < c; i++)
            {
                Position p = new Position(start.X - i, start.Y);
                buffer.Add(p);
            }
            buffer.Draw(ConsoleColor.White);
        }

    }
}