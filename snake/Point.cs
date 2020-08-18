using System;
using System.Collections.Generic;
using System.Text;

namespace snake
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point(int X, int Y, char Sym)
        {
            this.x = X;
            this.y = Y;
            this.sym = Sym;
        }

        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
            this.sym = p.sym;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void Clear()
        {
            sym = ' ';
            Draw();
        }
        

        public void Move(int OffSet, Direction direction)
        {
            if (direction == Direction.RIGHT)
            {
                x = x + OffSet;
            }
            if (direction == Direction.LEFT)
            {
                x = x - OffSet;
            }
            if (direction == Direction.UP)
            {
                y = y - OffSet;
            }
            if (direction == Direction.DOWN)
            {
                y = y + OffSet;
            }
        }

        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }
    }
}
