using HeonLee_Assignment1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeonLee_Assignment1
{
    class IntelligentKnight : Knight, KnightInterface
    {
        //Overiden automatic properties
        public override int X { get; set; }
        public override int Y { get; set; }
        
        public override ChessBoard cb { get; set; }

        int[,] choices = new int[2, 8] { { 2, 1, -1, -2, -2, -1, 1, 2 }
                , {-1, -2, -2, -1, 1, 2, 2, 1} };

        public IntelligentKnight()
        {
        }
        public override bool check(int x, int y)
        {
            return base.check(x, y);
        }

        private int lowestAccessibility(List<int> arr)
        {
            int lowestAccess = 9;
            int lowest = 0;
            for(int i = 0; i < arr.Count; i++)
            {
                if (cb.getAccessbility(this.X + choices[0, arr[i]], this.Y + choices[1, arr[i]]) <= lowestAccess)
                {
                    lowestAccess = cb.getAccessbility(this.X + choices[0, arr[i]], this.Y + choices[1, arr[i]]);
                    lowest = i;
                }
            }
            return arr[lowest];
        }

        public override bool move()
        {
            //First, find available moves
            //Second, find lowest accessbility from the set of available moves
            List<int> arr = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                int nextX = X + choices[0, i];
                int nextY = Y + choices[1, i];
                if (check(nextX, nextY))
                {
                    arr.Add(i);
                }
            }
            if(arr.Count == 0)
            {
                return false;
            }
            int lowest = lowestAccessibility(arr);
            this.X = this.X + choices[0, lowest];
            this.Y = this.Y + choices[1, lowest];
            return true;
        }
    }
}
