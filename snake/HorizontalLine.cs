using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class HorizontalLine : Figure
    {
        public HorizontalLine(int xRight, int xLeft, int y, char sym)
        {
            pList = new List<Point>();
            for (int i = xRight; i <= xLeft; i++)
            {
                Point p = new Point(i, y, sym);
                pList.Add(p);
            }
        }
    }
}
