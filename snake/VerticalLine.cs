using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class VerticalLine : Figure
    {
        public VerticalLine(int x, int yUp, int yDown, char sym)
        {
            pList = new List<Point>();
            for(int i = yUp; i <= yDown; i++)
            {
                Point p = new Point(x, i, sym);
                pList.Add(p);
            }
        }
    }
}
