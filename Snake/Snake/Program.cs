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

        static void InitializeScreen()
        {
            // Установка размера
            Console.SetBufferSize(WIDTH, HEIGHT);

            // Настройка рамочки
            VerticalLine leftLine = new VerticalLine(0, HEIGHT - 1, 0, '|');
            VerticalLine rightLine = new VerticalLine(0, HEIGHT - 1, WIDTH - 2, '|');
            HorizontalLine upLine = new HorizontalLine(0, WIDTH - 2, 0, '-');
            HorizontalLine downLine = new HorizontalLine(0, WIDTH - 2, HEIGHT - 1, '-');

            List<Figure> figures = new List<Figure>();

            figures.Add(leftLine);
            figures.Add(rightLine);
            figures.Add(upLine);
            figures.Add(downLine);

            // Отрисовка рамочки
            foreach (Figure figure in figures)
            {
                Draw(figure);
            }
        }

        static Snake InitializeSnake()
        {
            // Отрисовка точек змейки
            Point p = new Point(4, 5, '*');
            Figure fSnake = new Snake(p, 4, Direction.RIGHT);
            Draw(fSnake);
            return (Snake)fSnake;
        }

        static void Draw(Figure figure)
        {
            figure.Draw();
        }

        static void Main(string[] args)
        {
            // Инициализация
            InitializeScreen();
            Snake snake = InitializeSnake();

            // Создание еды
            FoodCreator foodCreator = new FoodCreator(WIDTH, HEIGHT, '$');
            Point food = foodCreator.CreateFood();

            while (true)
            {
                if (snake.Eat(food))
                    food = foodCreator.CreateFood();
                else
                    snake.Move();

                Thread.Sleep(SPEED);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
        }
    }
}
