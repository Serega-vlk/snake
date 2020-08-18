using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Wall
    {
        List<Figure> WallList;

        public Wall(int mapWeight, int mapHeight)
        {
            WallList = new List<Figure>();

            HorizontalLine upline = new HorizontalLine(0, mapWeight, 0, '+');
            HorizontalLine downline = new HorizontalLine(0, mapWeight, mapHeight, '+');
            VerticalLine leftline = new VerticalLine(0, 0, mapHeight, '+');
            VerticalLine rightline = new VerticalLine(mapWeight, 0, mapHeight, '+');
            WallList.Add(upline);
            WallList.Add(downline);
            WallList.Add(leftline);
            WallList.Add(rightline);
        }

        public void Draw()
        {
            foreach (var wall in WallList)
            {
                wall.Draw();
            }
        }

        public bool IsHit(Figure s)
        {
            foreach(var wall in WallList)
            {
                if (wall.IsHit(s))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
