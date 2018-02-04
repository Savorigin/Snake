using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {
        const int WIDTH = 80;
        const int HEIGHT = 25;
        const int SPEED = 100;

        static Walls InitializeScreen()
        {
            // Установка размера
            Console.SetBufferSize(WIDTH, HEIGHT);

            Walls walls = new Walls(WIDTH, HEIGHT);
            walls.Draw();

            return walls;
        }

        static Snake InitializeSnake()
        {
            // Отрисовка точек змейки
            Point p = new Point(4, 5, '*');

            Figure fSnake = new Snake(p, 4, Direction.RIGHT);
            fSnake.Draw();

            return (Snake)fSnake;
        }

        static void Draw(Figure figure)
        {
            figure.Draw();
        }

        static void Main(string[] args)
        {
            // Инициализация
            Walls walls = InitializeScreen();
            Snake snake = InitializeSnake();

            // Создание еды
            FoodCreator foodCreator = new FoodCreator(WIDTH, HEIGHT, '$');
            Point food = foodCreator.CreateFood();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    Console.WriteLine("Game over");
                    Console.ReadLine();
                    break;
                }

                if (snake.Eat(food))
                    food = foodCreator.CreateFood();
                else
                    snake.Move();

                Thread.Sleep(SPEED);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Key == ConsoleKey.Escape)
                        break;
                    snake.HandleKey(key.Key);
                }
            }
        }
    }
}
