using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace snake
{
    class Snake : Figure
    {
        public Direction direction;

        public Snake(Point tail, int lenght, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i <  lenght; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);
            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point NextPoint = new Point(head);
            NextPoint.Move(1, direction);
            return NextPoint;
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
                return false;
        }

        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count  - 2; i++)
            {
                if (head.IsHit(pList[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool SnakeLenght()
        {
            if (pList.Count % 5 == 0)
            {
                return true;
            }
            else
                return false;
        }

        public bool IsHitPoint(Point p)
        {
            foreach (var x in pList)
            {
                if (p.IsHit(x))
                {
                    return true;
                }
            }
            return false;
        }
    }
}