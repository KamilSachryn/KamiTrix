using KamiTrix;
using System.Diagnostics;
using System.Drawing;

const int height = 20;
const int width = 100;
const int maxLength = 16;
Random random = new Random();
Grid grid = new Grid(height, width);
StatusGrid status = new StatusGrid(maxLength);

Grid _oldGrid = new Grid(height, width);
StatusGrid _oldStatus = new StatusGrid(maxLength);

const int MS_REPEAT = 70;
const int PICK_NEW_HIGHLIGHT = 25;

grid.randomizeGrid();

ConsoleColor _default = ConsoleColor.Black;
ConsoleColor _black = ConsoleColor.Black;
ConsoleColor _darkBlue = ConsoleColor.DarkBlue;
ConsoleColor _darkGreen = ConsoleColor.DarkGreen;
ConsoleColor _darkCyan = ConsoleColor.DarkCyan;
ConsoleColor _darkRed = ConsoleColor.DarkRed;
ConsoleColor _darkMagenta = ConsoleColor.DarkMagenta;
ConsoleColor _darkYellow = ConsoleColor.DarkYellow;
ConsoleColor _gray = ConsoleColor.Gray;
ConsoleColor _darkGray = ConsoleColor.DarkGray;
ConsoleColor _blue = ConsoleColor.Blue;
ConsoleColor _green = ConsoleColor.Green;
ConsoleColor _cyan = ConsoleColor.Cyan;
ConsoleColor _red = ConsoleColor.Red;
ConsoleColor _magenta = ConsoleColor.Magenta;
ConsoleColor _yellow = ConsoleColor.Yellow;
ConsoleColor _white = ConsoleColor.White;

//ConsoleColor[] _colors = { _black, _darkBlue, _darkGreen, _darkCyan, _darkRed, _darkMagenta, _darkYellow, _gray, _darkGray, _blue, _green, _cyan, _red, _magenta, _yellow};
ConsoleColor[] _colors = { _black, _darkGreen, _green };

Console.BackgroundColor = ConsoleColor.Black;
Console.CursorVisible = false;




Stopwatch stopwatch = Stopwatch.StartNew();
bool init = true;

Stopwatch stopwatch1 = Stopwatch.StartNew();


while (true)
{
    if (stopwatch.ElapsedMilliseconds >= MS_REPEAT || init)
    {
        init = false;
        Console.Clear();
        grid.randomizeGrid();
        printCharacters(grid.getCharArr());
        status.tickColors();
        stopwatch.Restart();

    }

    if (stopwatch1.ElapsedMilliseconds >= PICK_NEW_HIGHLIGHT)
    {
        (int tempx, int tempy) = status.getRandomPosition();

        status.statusGrid[tempx][tempy] = maxLength;


        stopwatch1.Restart();
    }
}

void printCharacters(char[,] characters)
{
    /*
    for (int i = 0; i < height; i++)
    {
        for(int j = 0; j < width; j++)
        {
            if (status.statusGrid[i][ j] != 0)
            {
                
                int tmp = status.statusGrid[i][ j];
                Console.ForegroundColor = _colors[tmp];
            }
            Console.Write(grid.grid[i][j]);
            Console.ForegroundColor = _default;
        }
        Console.WriteLine();
    }
    */

    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {


            if (_oldGrid.grid[i][j] != grid.grid[i][j])
            {
                if (status.statusGrid[i][j] != 0)
                {


                    int tmp = status.statusGrid[i][j];

                    Console.SetCursorPosition(j, i);

                    if (tmp == maxLength)
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



    copyGrid();


}

void copyGrid()
{

    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            _oldGrid.grid[i][j] = grid.grid[i][j];
            _oldStatus.statusGrid[i][j] = status.statusGrid[i][j];
        }
    }


}
