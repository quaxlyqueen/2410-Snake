using System.ComponentModel;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Snake;

public class Program
{
    int leftMargin = 9;
    int topMargin = 0;
    private int height = 19;
    private int width = 31;
    private double difficulty;
    private int time;
    private Position[][] grid;
    private Position bottom { get; set; }
    private Position top { get; set; }


    static void Main(string[] args)
    {
        Program p = new Program();
          p.bottom = new Position(p.leftMargin, p.leftMargin + 1, p.topMargin + p.height);
          p.top = new Position(p.leftMargin, p.leftMargin + 1, p.topMargin);
          p.time = 0;
        p.PrintIntro();
        p.MenuInput();
    }

    void DrawSnake()
    {
        Snake s = new Snake(grid, 100);
        Timer t = new Timer(100);
        t.Elapsed += TimerAction;
        t.Enabled = true;
        if (!s.Move())
        {
            DisplayGameOver();
            Thread.Sleep(3000);
            PrintIntro();
            MenuInput();
        }
        else
        {
            DisplayNextLevel();
        }
    }

    void TimerAction(object? sender, ElapsedEventArgs elapsedEventArgs)
    {
        time++;
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

    // TODO: Can no longer press q or r after starting the game.
    void MenuInput()
    {
        Console.SetCursorPosition(bottom.X1, bottom.Y);
        Console.Write("Enter p to play, q to quit, r for rules:                     ");
        char input = Console.ReadKey().KeyChar;
        Console.SetCursorPosition(bottom.X1, bottom.Y);
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
                    }
                    DrawGameBoard(grid);
                    DrawSnake();
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
        time = 0;
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

    // TODO: ASCII art for game over screen
    void DisplayGameOver()
    {
        string[] s =
        {
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣠⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣤⠀⠀⠀⢀⣴⣿⡶⠀⣾⣿⣿⡿⠟⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣄⣀⠀⠀⠀⠀⣶⣶⣦⠀⠀⠀⠀⣼⣿⣿⡇⠀⣠⣿⣿⣿⠇⣸⣿⣿⣧⣤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣾⣿⡿⠿⠿⠿⠇⠀⠀⣸⣿⣿⣿⡆⠀⠀⢰⣿⣿⣿⣷⣼⣿⣿⣿⡿⢀⣿⣿⡿⠟⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣿⡿⠋⠁⠀⠀⠀⠀⠀⠀⢠⣿⣿⣹⣿⣿⣿⣿⣿⣿⡏⢻⣿⣿⢿⣿⣿⠃⣼⣿⣯⣤⣴⣶⣿⡤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⠏⠀⣀⣠⣤⣶⣾⣷⠄⣰⣿⣿⡿⠿⠻⣿⣯⣸⣿⡿⠀⠀⠀⠁⣾⣿⡏⢠⣿⣿⠿⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⠲⢿⣿⣿⣿⣿⡿⠋⢰⣿⣿⠋⠀⠀⠀⢻⣿⣿⣿⠇⠀⠀⠀⠀⠙⠛⠀⠀⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⢿⣷⣶⣿⣿⠿⠋⠀⠀⠈⠙⠃⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣤⣴⣶⣦⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⣠⡇⢰⣶⣶⣾⡿⠷⣿⣿⣿⡟⠛⣉⣿⣿⣿⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣶⣿⣿⡎⣿⣿⣦⠀⠀⠀⢀⣤⣾⠟⢀⣿⣿⡟⣁⠀⠀⣸⣿⣿⣤⣾⣿⡿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⡿⠛⠉⢿⣦⠘⣿⣿⡆⠀⢠⣾⣿⠋⠀⣼⣿⣿⣿⠿⠷⢠⣿⣿⣿⠿⢻⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣿⣿⠋⠀⠀⠀⢸⣿⣇⢹⣿⣷⣰⣿⣿⠃⠀⢠⣿⣿⢃⣀⣤⣤⣾⣿⡟⠀⠀⠀⢻⣿⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⡇⠀⠀⢀⣴⣿⣿⡟⠀⣿⣿⣿⣿⠃⠀⠀⣾⣿⣿⡿⠿⠛⢛⣿⡟⠀⠀⠀⠀⠀⠻⠿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣶⣾⣿⣿⣿⠟⠁⠀⠸⢿⣿⠇⠀⠀⠀⠛⠛⠁⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠛⠛⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀",
            "⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀"
        };
        // Prints score and time below ASCII art of same dimension as the snake drawing above
        PrintConsole($"Score: {time * 100} | Time: {time / 10} seconds               ");
        PrintConsole(s);
        time = 0;
    }

    void DisplayNextLevel()
    {
        grid = GenerateGameBoard(grid, difficulty * (1 + difficulty));
        DrawGameBoard(grid);
        DrawSnake();
    }

    void PrintConsole(string message)
    {
        Console.SetCursorPosition(bottom.X1, bottom.Y + 1);
        Console.WriteLine(message);
    }

    void PrintConsole(string[] s)
    {
        Console.BackgroundColor = ConsoleColor.Black;
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