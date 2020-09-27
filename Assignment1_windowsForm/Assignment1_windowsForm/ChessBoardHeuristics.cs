using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonLee_Assignment1
{
    internal partial class ChessBoard
    {
        //This side of class contains heuristics
        private int[,] heuristics;

        private void generateHeuristics()
        {
            heuristics = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j >= 2 && j <= 5 && i >= 2 && i <= 5)
                    {
                        heuristics[i, j] = 8;
                    }
                    else if ((i == 1 && j >= 2 && j <= 5) ||
                             (i >= 2 && i <= 5 && j == 1) ||
                             (i == 6 && j <= 5 && j >= 2) ||
                             (i >= 2 && i <= 5 && j == 6))
                    {
                        heuristics[i, j] = 6;
                    }
                    else if ((i == 0 && j == 0) || (i == 0 && j == 7)
                              || (i == 7 && j == 0) || (i == 7 && j == 7))
                    {
                        heuristics[i, j] = 2;
                    }
                    else if (i == 0 && j == 1 || i == 1 && j == 0 || i == 6 && j == 0 || i == 7 && j == 1
                      || i == 0 && j == 6 || i == 1 && j == 7 || i == 7 && j == 6 || i == 6 && j == 7)
                    {
                        heuristics[i, j] = 3;
                    }
                    else
                    {
                        heuristics[i, j] = 4;
                    }
                }
            }
        }

        public int getAccessbility(int x, int y)
        {
            return heuristics[x, y];
        }
    }
}