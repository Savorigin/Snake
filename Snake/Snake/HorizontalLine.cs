using System;

namespace Snake
{
    class HorizontalLine : Figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            for (int x = xLeft; x <= xRight; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);
            }
        }

        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            /*foreach (Point p in pList)
            {
                p.Draw();
            }*/

            base.Draw();

            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
