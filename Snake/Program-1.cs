
using System.Runtime.Intrinsics.X86;
using Snake;


namespace Snake
{
    public class Program
    {

        public static void Main(string[] args)
        {
            /*   
               int[][] array = GenerateGameBoard(40, 20, 10);
                 for (int i = 0; i < array.Length; i++)
                 {
                     for (int j = 0; j < array[i].Length; j++)
                     {
                         Console.Write(array[i][j] + " ");
                     }
                     Console.WriteLine();
                 }

           */
            Printconsole();

            //input();
        }



        //prints the cosole and gives the user the menu option
        static void Printconsole()
        {

            int leftMargin = 30;
            int topMargin = 5;
            //int consoleWidth = 300;
            //int consoleHeight = 300;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            // Calculate the top margin to center the content vertically
            //int topMargin = (consoleHeight - 10) / 2;

            // Output the top border
            //Console.WriteLine("╔" + "".PadRight(consoleWidth - 2, '═') + "╗");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin;
            Console.WriteLine(" WELCOME TO THE SNAKE GAME ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("╔═════════════════════════════════════════════════════════════╗");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("                /^\\/^\\                                       ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("              _|__|  O|                                        ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("     \\/     /~      \\_/ \\                                   ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("      \\____|__________/  \\                                   ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("             \\_______      \\                                 ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("                     '\\     \\                 \\             ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("                       |     |                   \\            ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("                      /      /                    \\           ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("                    /     /                       \\\\         ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("                  /     /                         \\  \\\\     ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("                /     /             _----_         \\   \\\\   ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("              /     /           _-~      ~-_         |   |     ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("             (      (    _-~    _--_    ~-_     _/   |         ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("             \\      ~-____-~    _-~   ~-_    ~-_-~    /       ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("              ~-_           _-~          ~-_       _-~         ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("                 ~--______-~                ~-___-~            ");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;
            Console.WriteLine("╚═════════════════════════════════════════════════════════════╝");
            Console.CursorLeft = leftMargin;
            Console.CursorTop = topMargin++;


            // Output the bottom border
            //Console.WriteLine("╚" + "".PadRight(consoleWidth - 2, '═') + "╝");

            input();
            Console.ResetColor();
        }





        static void input()
        {
            Console.WriteLine("Enter p to play, q to quit, r for rules");
            char input = Console.ReadKey().KeyChar;
            while (input != 'q')
            {
                switch (input)
                {
                    case 'p':
                        Console.Clear(); // clear the console
                        int gridleftMargin = 30;
                        Console.CursorLeft = gridleftMargin;
                        Console.WriteLine("Enter e for easy, m for medium, and h for hard");
                        char level = Console.ReadKey().KeyChar;
                        int[][] grid = null;
                        switch (level)
                        {
                            case 'e':
                                grid = GenerateGameBoard(40, 20, 0.03);

                                break;
                            case 'm':
                                grid = GenerateGameBoard(40, 20, 0.06);
                                break;
                            case 'h':
                                grid = GenerateGameBoard(40, 20, 0.1);
                                break;
                            default:
                                Console.WriteLine("Invalid level entered.");
                                break;
                        }
                        if (grid != null)
                        {
                            DrawGameBoard(grid);
                            Position p = new Position(15, 15);
                            Snake s = new Snake(10, grid, p);
                            Console.BackgroundColor = ConsoleColor.Black;

                            // loop of some kind
                            for(int i = 0; i < (grid.Length * 2) - 2; i++)
                            {
                                s.move(0);
                                Thread.Sleep(600);
                            }
                        }
                        break;
                    case 'q':
                        Environment.Exit(0);
                        break;
                    case 'r':
                        Rules();
                        // Code to execute to see Rules
                        break;
                    // Add as many cases as you need
                    default:
                        // Code to execute if variable doesn't match any of the cases
                        break;
                }
                Console.WriteLine();
                Console.CursorLeft = 30;
                Console.WriteLine("Enter p to play, q to quit, r for rules");
                input = Console.ReadKey().KeyChar;
            }
        }

        static int[][] GenerateGameBoard(int width, int height, double obstacleProbability)
        {
            int[][] grid = new int[height][];

            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = new int[width];
                for (int j = 0; j < grid[i].Length; j++)
                {
                    grid[i][j] = 0;
                }
            }

            // Add borders to the grid
            for (int i = 0; i < width; i++)
            {
                grid[0][i] = 1;
                grid[height - 1][i] = 1;
            }
            for (int j = 0; j < height; j++)
            {
                grid[j][0] = 1;
                grid[j][width - 1] = 1;
            }

            Random r = new Random();
            
            for (int i = 1; i < grid.Length - 1; i++)
            {
                for (int j = 1; j < grid[i].Length - 1; j++)
                {
                    if (r.NextDouble() <= obstacleProbability)
                    {
                        grid[i][j] = 1;
                    }
                }
            }
            

            return grid;
        }



        static void DrawGameBoard(int[][] grid)
        {

            Console.WriteLine();
            Console.CursorTop = (15);
            int leftMargin = 30;

            for (int i = 0; i < grid.Length; i++)
            {
                Console.CursorLeft = leftMargin;
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                Console.WriteLine();
            }
        }

        //prints the rules with a grid to console and snake in the middle of grid
        static void Rules()
        {
            Console.Clear(); // clear the console
            Console.WriteLine();

            int gridleftMargin = 30;
            //int gridTopMargin = 36;
            int width = 61;
            int height = 60;
            int snakeLength = 5;
            int obstacle = 10;

            //makes a grid of width and height above
            int[,] grid = new int[width, height];

            // Place the snake in the middle of the grid
            int x = (width - snakeLength) / 2;
            int y = height / 2;

            //make the snake
            for (int i = 0; i < snakeLength; i++)
            {
                //head of snake
                if (i == 0)
                {
                    grid[x + i, y] = 2;
                }

                //tail of snake
                else
                    grid[x + i, y] = 1;
            }

            //place obstcales in grid
            Random random = new Random();
            for (int i = 0; i < obstacle; i++)
            {
                int a = random.Next(1, width - 1);
                int b = random.Next(1, height - 1);
                if (grid[a, b] == 0)
                {
                    grid[a, b] = 3;
                }
                else
                {
                    i--;
                }
            }

            Console.CursorLeft = gridleftMargin;
            // Print the grid to the console
            for (int j = 0; j < height; j++)
            {
                Console.CursorLeft = gridleftMargin;
                for (int i = 0; i < width; i++)
                {
                    //this prints the border on Left and Right side

                    if (i == 0 || i == width - 1)
                    {
                        Console.Write("||");
                    }
                    //this prints the border on Top and Bottom side
                    else if (j == 0 || j == height - 1)
                    {
                        Console.Write("=");
                    }

                    else if (grid[i, j] == 0)
                    {
                        Console.Write(" ");
                    }

                    //Tail of snake
                    else if (grid[i, j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("           ");
                        i += 10;
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    //prints the head of snake
                    else if (grid[i, j] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("< ");
                        i += 1;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.BackgroundColor = ConsoleColor.Black;

                    }

                    //prints more obstacles
                    else if (grid[i, j] == 4)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    //Prints the obstacles
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.Write(" ");
                        Console.BackgroundColor = ConsoleColor.Black;

                        //print obstacle on rule board
                        if (i < width - 14)
                        {
                            Console.Write("<--- obstacle");
                            i += 13;
                        }

                    }
                }


                Console.WriteLine();
            }
            Console.CursorLeft = gridleftMargin;
            Console.WriteLine("The rules of the game is to not let the head of the sanke \n");
            Console.CursorLeft = gridleftMargin;
            Console.WriteLine("represented as ( < ) hit the walls or any obstcles. You will \n");
            Console.CursorLeft = gridleftMargin;
            Console.WriteLine("use the arrow keys on your keyboard to control the snake. \n");
            Console.CursorLeft = gridleftMargin;
            Console.WriteLine("you will also colletc points for how long you can stay alive");

        }
    }
}
