using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class FoodCreator
    {
        int mapWigth;
        int mapHeigth;
        char sym;

        Random rand = new Random();

        public FoodCreator(int W, int H, char S)
        {
            this.mapHeigth = H;
            this.mapWigth = W;
            this.sym = S;
        }

        public Point CreateFood()
        {
            int x = rand.Next(2, mapWigth - 2);
            int y = rand.Next(2, mapHeigth - 2);
            return new Point(x, y, sym);
        }
    }
}
