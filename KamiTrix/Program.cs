using KamiTrix;
using System.Diagnostics;
using System.Drawing;

//default settings for unmodified windows 11 console
const int CONSOLE_HEIGHT = 20;
const int CONSOLE_WIDTH = 100;
const int MAX_TRAIL_LENGTH = 16;
const int MS_REPEAT = 70;
const int MS_TICK_NEW_HIGHLIGHT = 25;

ConsoleColor _default = ConsoleColor.Black;
ConsoleColor _black = ConsoleColor.Black;
ConsoleColor _darkGreen = ConsoleColor.DarkGreen;
ConsoleColor _blue = ConsoleColor.Blue;

Console.BackgroundColor = ConsoleColor.Black;
Console.CursorVisible = false;

//tick cycle
Stopwatch stopwatchTick = Stopwatch.StartNew();
Stopwatch stopwatchNewTrail = Stopwatch.StartNew();

//object representations
Grid grid = new Grid(CONSOLE_HEIGHT, CONSOLE_WIDTH);
StatusGrid status = new StatusGrid(MAX_TRAIL_LENGTH);

//tick to tick change for optimization
//trade memory for speed
Grid _oldGrid = new Grid(CONSOLE_HEIGHT, CONSOLE_WIDTH);
StatusGrid _oldStatus = new StatusGrid(MAX_TRAIL_LENGTH);


//Initial console setup
grid.randomizeGrid();


Random random = new Random();


//initial setup at ms == 0
bool init = true;

while (true)
{
    //refresh console
    if (stopwatchTick.ElapsedMilliseconds >= MS_REPEAT || init)
    {
        init = false;
        Console.Clear();
        grid.randomizeGrid();
        printCharacters(grid.getCharArr());
        status.tickColors();

        stopwatchTick.Restart();
    }

    //start new trail
    if (stopwatchNewTrail.ElapsedMilliseconds >= MS_TICK_NEW_HIGHLIGHT)
    {
        (int tempx, int tempy) = status.getRandomPosition();
        status.statusGrid[tempx][tempy] = MAX_TRAIL_LENGTH;

        stopwatchNewTrail.Restart();
    }
}

//reads through the grids to check for changed characters and colors,
//writes new character directly to position

void printCharacters(char[,] characters)
{
    for (int i = 0; i < CONSOLE_HEIGHT; i++)
    {
        for (int j = 0; j < CONSOLE_WIDTH; j++)
        {
            //if a character is changed
            if (_oldGrid.grid[i][j] != grid.grid[i][j])
            {
                //if it is colored
                if (status.statusGrid[i][j] != 0)
                {
                    //set current character to desired color
                    //blue for trail head
                    //green for tail
                    int tmp = status.statusGrid[i][j];

                    Console.SetCursorPosition(j, i);

                    if (tmp == MAX_TRAIL_LENGTH)
                    {
                        Console.ForegroundColor = _blue;
                    }
                    else if (tmp > 1)
                    {
                        Console.ForegroundColor = _darkGreen;
                    }
                    else
                    {
                        Console.ForegroundColor = _black;
                    }
                    Console.Write(grid.grid[i][j]);
                    Console.ForegroundColor = _default;
                }
            }

        }
        Console.WriteLine();

    }

    //copy grids without assignment to oldgrids
    for (int i = 0; i < CONSOLE_HEIGHT; i++)
    {
        for (int j = 0; j < CONSOLE_WIDTH; j++)
        {
            _oldGrid.grid[i][j] = grid.grid[i][j];
            _oldStatus.statusGrid[i][j] = status.statusGrid[i][j];
        }
    }


}
