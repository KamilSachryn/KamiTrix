using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KamiTrix
{
    //Keeps track of colors for the matrix
    internal class StatusGrid
    {
        //default values 
        const int height = 20;
        const int width = 100;
        int maxLength;
        public List<List<int>> statusGrid = new List<List<int>>();


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

        //returns random board position for trail beggining
        public (int, int) getRandomPosition()
        {
            Random random = new Random();
            return (random.Next(0, height), random.Next(0, width));
        }

        //protect against out of range
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
        
        //changes status of new trails to 'blue' and old trails to 'green'
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
