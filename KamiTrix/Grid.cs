using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiTrix
{
    internal class Grid
    {
        int height;
        int width;
        public List<List<char>> grid = new List<List<char>>();

        public Grid(int height, int width)
        {
            this.height = height;
            this.width = width;

            for (int i = 0; i < height; i++)
            {
                grid.Add(new List<char>());
                for (int j = 0; j < width; j++)
                {
                    grid[i].Add(i.ToString()[0]);
                }
            }
        }

        public void randomizeGrid()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Random r = new Random();
                    char randASCII = (char)r.Next(65, 91);
                    grid[i][j] = randASCII;

                }
            }
        }

        (int, int) getRandomPosition()
        {
            Random random = new Random();
            return (random.Next(0, height), random.Next(0, width));
        }

        (int, int) getNext(int h, int w)
        {
            return (h - 1, w);
        }

        public bool validBelow(int h)
        {
            return h < height;

        }

        public string getStringArr()
        {
            string output = "";
            foreach (List<char> charList in grid)
            {
                string tmp = "";

                foreach (char c in charList)
                {
                    tmp += c;
                }

                output += tmp;
                output += "\n";


            }

            return output;
        }

        public char[,] getCharArr()
        {
            char[,] output = new char[height, width];

            for(int i = 0; i < height; i++)
            {
                for(int j = 0; j < width; j++)
                {
                    output[i, j] = grid[i][j];
                }
            }

            return output;
        }


    }
}
