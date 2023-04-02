namespace Snake;

public class Program
{
    int leftMargin = 9;
    int topMargin = 0;
    private int height = 19;
    private int width = 31;
    private Position[][] grid;
    private Position bottom { get; set; }
    private Position top { get; set; }


    static void Main(string[] args)
    {
        Program p = new Program();
          p.bottom = new Position(p.leftMargin, p.leftMargin + 1, p.topMargin + p.height);
          p.top = new Position(p.leftMargin, p.leftMargin + 1, p.topMargin);
        p.PrintIntro();
        p.MenuInput();
    }

    void PrintSnake()
    {
        Snake s = new Snake(grid, 100);
        s.Move();
    }

    void PrintIntro()
    {
        string[] s =
        {
            "╔════════════════════════════════════════════════════════════╗",
            "               /^\\/^\\                                       ",
            "             _|__|  O|                                        ",
            "    \\/     /~      \\_/ \\                                   ",
            "     \\____|__________/  \\                                   ",
            "            \\_______      \\                                 ",
            "                    '\\     \\                 \\             ",
            "                      |     |                   \\            ",
            "                     /      /                    \\           ",
            "                   /     /                       \\\\         ",
            "                   /     /                       \\\\         ",
            "                 /     /                         \\  \\\\     ",
            "               /     /             _----_         \\   \\\\   ",
            "             /     /           _-~      ~-_         |   |     ",
            "            (      (    _-~    _--_    ~-_     _/   |         ",
            "            \\      ~-____-~    _-~   ~-_    ~-_-~    /       ",
            "             ~-_           _-~          ~-_       _-~         ",
            "                ~--______-~                ~-___-~            ",
            "╚════════════════════════════════════════════════════════════╝"
        };
        PrintConsole(s);
    }

    void MenuInput()
    {
        Console.SetCursorPosition(bottom.X1, bottom.Y);
        Console.Write("Enter p to play, q to quit, r for rules:                     ");
        char input = Console.ReadKey().KeyChar;
        Console.SetCursorPosition(bottom.X1, bottom.Y);
        Console.WriteLine("");
        while (input != 'q')
        {
            switch (input)
            {
                case 'p':
                    Console.SetCursorPosition(bottom.X1, bottom.Y);
                    Console.Write("Enter e for easy, m for medium, and h for hard:              ");
                    char level = Console.ReadKey().KeyChar;
                    grid = new Position[height][];
                    switch (level)
                    {
                        case 'e':
                            grid = GenerateGameBoard(grid, 0.03);
                            break;
                        case 'm':
                            grid = GenerateGameBoard(grid, 0.06);
                            break;
                        case 'h':
                            grid = GenerateGameBoard(grid, 0.1);
                            break;
                        default:
                            grid = GenerateGameBoard(grid, 0.1);
                            break;
                    }
                    Console.SetCursorPosition(top.X1, top.Y);
                    DrawGameBoard(grid);
                    break;
                case 'q':
                    Environment.Exit(0);
                    break;
                case 'r':
                    DisplayRules();
                    break;
            }
        }
    }

    void DrawGameBoard(Position[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[i].Length; j++)
            {
                Console.SetCursorPosition(grid[i][j].X1, grid[i][j].Y);
                grid[i][j].Draw(false);
            }
            Console.WriteLine();
        }
        PrintSnake();
    }

    void DisplayRules()
    {
        Position[][] grid = new Position[height][];
            grid = GenerateGameBoard(grid, 0.03);
            DrawGameBoard(grid);
            
        string rules = (
            "RULES:\n" +
            "           - Do not let the snake head touch walls or obstacles.\n" +
            "           - Use the arrow keys to control the snake."
            //"    - Collect all points in a level to move to the next level.",
            //"    - Levels increase difficulty."
        );
        PrintConsole(rules);
    }

    void PrintConsole(string message)
    {
        Console.SetCursorPosition(bottom.X1, bottom.Y + 1);
        Console.WriteLine(message);
    }

    void PrintConsole(string[] s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            Console.SetCursorPosition(top.X1, top.Y + i);
            Console.WriteLine(s[i]);
        }
    }
    
    private Position[][] GenerateGameBoard(Position[][] grid, double chance)
    {
        int xCounter = 0;
        for (int y = 0; y < grid.Length; y++)
        {
            grid[y] = new Position[width];
            for (int x = 0; x < grid[y].Length; x++)
            {
                if (x == 0 || x == grid[y].Length - 1 || y == 0 || y == grid.Length - 1 ||
                    new Random().NextDouble() <= chance)
                {
                    grid[y][x] = new Position(xCounter++ + leftMargin, xCounter++ + leftMargin, y + topMargin, true);
                }
                else
                {
                    grid[y][x] = new Position(xCounter++ + leftMargin, xCounter++ + leftMargin, y + topMargin, false);
                }
            }
            xCounter = 0;
        }
        return grid;
    }
}