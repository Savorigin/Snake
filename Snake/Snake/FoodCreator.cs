﻿using System;

namespace Snake
{
    class FoodCreator
    {
        private int mapWidth;
        private int mapHeight;
        private char sym;

        private Random random = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood()
        {
            int x = random.Next(2, mapWidth - 2);
            int y = random.Next(2, mapHeight - 2);
            Point food = new Point(x, y, sym);
            food.Draw();
            return food;
        }
    }
}
