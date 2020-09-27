using HeonLee_Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonLee_Assignment1
{
    interface KnightInterface
    {
        int X { get; set; }
        int Y { get; set; }
        ChessBoard cb { get; set; }
        bool check(int x, int y);//Checks if x and y are inside the range of 
                                 //1..8
        bool move();
    }
}
