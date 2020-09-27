using HeonLee_Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonLee_Assignment1
{
    class Knight : KnightInterface
    {
        //Automatic properties
        public virtual int X { get; set; }
        public virtual int Y { get; set; }

        public virtual ChessBoard cb { get; set; }
        public Knight()
        {
        }

        public virtual bool check(int x, int y)
        {
            if(x >= 0 && y >= 0 && x <= 7 && y <= 7 && cb.getValue(x,y) == 0)
            {
                return true;
            }
            return false;
        }

        public virtual bool move(){
            int[,] choices = new int[2, 8] { { 2, 1, -1, -2, -2, -1, 1, 2 }
                , {-1, -2, -2, -1, 1, 2, 2, 1} }; //From position 0 - 7. First one is a difference in 
            //X, and the second one is a difference in Y
            for(int i =  0; i < 8; i++)
            {
                int nextX = this.X + choices[0, i];
                int nextY = this.Y + choices[1, i];
                if(check(nextX, nextY))
                {
                    this.X = nextX;
                    this.Y = nextY;
                    return true;
                }
            }
            return false;
        }
    }
}
