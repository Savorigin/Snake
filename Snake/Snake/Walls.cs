using System.Collections.Generic;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '|');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '|');
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '-');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '-');

            wallList.Add(leftLine);
            wallList.Add(rightLine);
            wallList.Add(upLine);
            wallList.Add(downLine);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                    return true;
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
