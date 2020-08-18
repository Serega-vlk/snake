using System;
using System.Threading;

namespace snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int choise;
            int mode;
            int speed;
        menu:
            Console.Clear();
            Console.WriteLine("\t$ ЗМЕЙКА ВОЛКОВА $\t telegram автора: serega_vlk\n\n");
            Console.WriteLine("1. играть");
            Console.WriteLine("2. выход");
            choise = Convert.ToInt32(Console.ReadLine());
            if (choise == 1)
            {
            menu1:
                Console.Clear();
                Console.WriteLine("\t$ ЗМЕЙКА ВОЛКОВА $\t telegram автора: serega_vlk\n\n");
                Console.WriteLine("Выберите сложность\n");
                Console.WriteLine("1. Тренировка");
                Console.WriteLine("2. Арена");
                Console.WriteLine("3. Назад");
                choise = Convert.ToInt32(Console.ReadLine());
                if (choise == 1)
                {
                    Console.Clear();
                    mode = 1;
                }
                else if (choise == 2)
                {
                    Console.Clear();
                    mode = 2;
                }
                else if (choise == 3)
                {
                    Console.Clear();
                    goto menu;
                }
                else
                {
                    Console.Clear();
                    goto menu1;
                }
            menu2:
                Console.Clear();
                Console.WriteLine("\t$ ЗМЕЙКА ВОЛКОВА $\t telegram автора: serega_vlk\n\n");
                Console.WriteLine("Выберите скорость\n");
                Console.WriteLine("1. Легкая - 130");
                Console.WriteLine("2. Средняя - 100");
                Console.WriteLine("3. Сложная - 70");
                Console.WriteLine("4. Хардкор - 40");
                Console.WriteLine("5. Назад");
                choise = Convert.ToInt32(Console.ReadLine());
                if (choise == 1)
                {
                    Console.Clear();
                    speed = 130;
                    goto start;
                }
                else if (choise == 2)
                {
                    Console.Clear();
                    speed = 100;
                    goto start;
                }
                else if (choise == 3)
                {
                    Console.Clear();
                    speed = 70;
                    goto start;
                }
                else if (choise == 4)
                {
                    Console.Clear();
                    speed = 40;
                    goto start;
                }
                else if (choise == 5)
                {
                    Console.Clear();
                    goto menu1;
                }
                else
                {
                    Console.Clear();
                    goto menu2;
                }
            }
            else if (choise == 2)
                return;
            else
            {
                Console.Clear();
                goto menu;
            }
        start:
            int weight = 80;
            int height = 25;
            Wall frames = new Wall(weight, height);
            frames.Draw();
            Point p = new Point(5, 4, '#');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodcreator = new FoodCreator(weight, height, '%');
            Point food = foodcreator.CreateFood();
            food.Draw();

            Console.SetCursorPosition(90, 0);
            Console.Write("Для выхода нажмите esc");
            Console.SetCursorPosition(90, 2);
            Console.Write("Сложность: " + mode);
            Console.SetCursorPosition(90, 3);
            Console.Write("Скорость: " + speed);

            int counter = 0;
            bool check = true;

            while(true)
            {
                if (snake.SnakeLenght() && check && mode == 2)
                {
                    weight = weight - 4;
                    height = height - 1;
                    Console.Clear();
                    foodcreator = new FoodCreator(weight - 5, height - 2, '%');
                    frames = new Wall(weight, height);
                    frames.Draw();
                    food.Draw();
                    snake.Draw();
                    Console.SetCursorPosition(90, 0);
                    Console.Write("Для выхода нажмите esc");
                    Console.SetCursorPosition(90, 2);
                    Console.Write("Сложность: " + mode);
                    Console.SetCursorPosition(90, 3);
                    Console.Write("Скорость: " + speed);
                    check = false;
                }
                if (frames.IsHit(snake) || snake.IsHitTail())
                {
                    Console.SetCursorPosition(90, 15);
                    Console.Write("Вы проиграли(((");
                    Console.SetCursorPosition(90, 17);
                    Console.Write("Ваш счет: " + Convert.ToString(counter));
                    Console.SetCursorPosition(90, 19);
                    Console.Write("Нажмите esc для выхода в меню");
                    while (true)
                    {
                        ConsoleKeyInfo key1 = Console.ReadKey();
                        if (key1.Key == ConsoleKey.Escape)
                            break;
                    }
                    goto menu;
                }
                if (snake.Eat(food))
                {
                    counter++;
                    while (true)
                    {
                        food = foodcreator.CreateFood();
                        if (snake.IsHitPoint(food))
                        {
                            continue;
                        }
                        else
                            break;
                    }
                    food.Draw();
                    check = true;
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(speed);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.LeftArrow)
                        snake.direction = Direction.LEFT;
                    else if (key.Key == ConsoleKey.RightArrow)
                        snake.direction = Direction.RIGHT;
                    else if (key.Key == ConsoleKey.UpArrow)
                        snake.direction = Direction.UP;
                    else if (key.Key == ConsoleKey.DownArrow)
                        snake.direction = Direction.DOWN;
                    else if (key.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Console.SetCursorPosition(0, 0);
                        goto menu;
                    }
                }
            }
        }
    }
}