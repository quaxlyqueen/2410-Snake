using Snake;

PrintConsole();
//private Position[][] grida;

void PrintConsole()
{
    int leftMargin = 30;
    int topMargin = 5;

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

    input();
    Console.ResetColor();
}

void input()
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
                Position[][] grid = new Position[20][];
                switch (level)
                {
                    case 'e':
                        grid = GenerateGameBoard(grid, 0.03);
                        break;
                    case 'm':
                        grid = GenerateGameBoard(grid,  0.06);
                        break;
                    case 'h':
                        grid = GenerateGameBoard(grid,  0.1);
                        break;
                    default:
                        Console.WriteLine("Invalid level entered.");
                        break;
                }
                if (grid != null)
                {
                    DrawGameBoard(grid);
                    Position p = new Position(15, 15, 0, false);
                    //Snake s = new Snake.Snake(10, grid, p);
                    Console.BackgroundColor = ConsoleColor.Black;

                    for(int i = 0; i < (grid.Length * 2) - 2; i++)
                    {
                        //s.move(0);
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

static Position[][] GenerateGameBoard(Position[][] grid, double chance)
{
    int xCounter = 0;
    for (int y = 0; y < grid.Length; y++)
    {
        grid[y] = new Position[20];
        for (int x = 0; x < grid.Length; x++)
        {
            if (x == 0 || x == grid[y].Length - 1 || y == 0 || y == grid.Length - 1 || new Random().NextDouble() <= chance)
                grid[y][x] = new Position(xCounter++, xCounter++, y, true);
            else
                grid[y][x] = new Position(xCounter++, xCounter++, y, false);
        }
        xCounter = 0;
    }
    return grid;
}

void DrawGameBoard(Position[][] grid)
{
    Console.WriteLine();
    for (int i = 0; i < grid.Length; i++)
        for (int j = 0; j < grid[i].Length; j++)
                grid[i][j].Draw();
            Console.WriteLine();
}

static void Rules()
{
    Console.Clear();
    Console.WriteLine();

    int gridleftMargin = 30;
    int width = 61;
    int height = 60;
    int snakeLength = 5;
    int obstacle = 10;

    int[,] grid = new int[width, height];

    int x = (width - snakeLength) / 2;
    int y = height / 2;

    for (int i = 0; i < snakeLength; i++)
    {
        if (i == 0)
        {
            grid[x + i, y] = 2;
        }

        else
            grid[x + i, y] = 1;
    }

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
    for (int j = 0; j < height; j++)
    {
        Console.CursorLeft = gridleftMargin;
        for (int i = 0; i < width; i++)
        {

            if (i == 0 || i == width - 1)
            {
                Console.Write("||");
            }
            else if (j == 0 || j == height - 1)
            {
                Console.Write("=");
            }

            else if (grid[i, j] == 0)
            {
                Console.Write(" ");
            }

            else if (grid[i, j] == 1)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write("           ");
                i += 10;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else if (grid[i, j] == 2)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("< ");
                i += 1;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;

            }

            else if (grid[i, j] == 4)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;

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
