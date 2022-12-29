using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiTrix
{
    internal class StatusGrid
    {
        const int height = 20;
        const int width = 100;
        int maxLength;
        //public int[,] statusGrid = new int[height, width];
        public List<List<int>> statusGrid = new System.Collections.Generic.List<List<int>>();
        public StatusGrid(int maxLength)
        {
            this.maxLength = maxLength;


            for (int i = 0; i < height; i++)
            {
                statusGrid.Add(new List<int>());
                for (int j = 0; j < width; j++)
                {
                    statusGrid[i].Add(0);
                }
            }
        }

        public (int, int) getRandomPosition()
        {
            Random random = new Random();
            return (random.Next(0, height), random.Next(0, width));
        }

        public (int, int) getNext(int h, int w)
        {
            return (h - 1, w);
        }

        public bool validBelow(int h)
        {
            return h < height - 1;

        }

        //returns a list of all positions which have a color other than 0
        public List<(int, int)> getPositionsToTick()
        {
            List<(int, int)> output = new List<(int, int)>();
            output.Clear();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (statusGrid[i][j] != 0)
                    {
                        output.Add((i, j));
                    }
                }
            }

            return output;

        }
        //so if we have a list of non-0s
        //we want to tick them down 
        //and move it's color down 
        //Move color down  then tick?
        public void tickColors()
        {
            List<(int, int)> posistions = getPositionsToTick();

            foreach ((int h, int w) in posistions)
            {

                if (statusGrid[h][w] == maxLength)
                {
                    statusGrid[h][w] = maxLength - 1;
                    if (validBelow(h))
                    {

                        statusGrid[h + 1][w] = maxLength;

                    }
                }
                else
                {
                    statusGrid[h][w]--;
                }


            }



        }


    }
}
