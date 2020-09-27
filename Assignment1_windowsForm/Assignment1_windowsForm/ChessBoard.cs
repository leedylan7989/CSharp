using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonLee_Assignment1
{
    internal partial class ChessBoard
    {
        //This side of class contains normal chessboard. Normal chessboard 
        //will record a knight's path. 
        private int[,] board;

        public ChessBoard(bool intelligence)
        {
            board = new int[8, 8];
            if (intelligence)
            {
                generateHeuristics();
            }
        }

        public int getValue(int x, int y)
        {
            return board[x, y];
        }

        public void setValue(int x, int y, int value)
        {
            board[x, y] = value;
        }
    }
}