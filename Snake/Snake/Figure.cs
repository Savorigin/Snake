﻿using System.Collections.Generic;

namespace Snake
{
    class Figure
    {
        protected List<Point> pList;

        public Figure()
        {
            pList = new List<Point>();
        }

        public virtual void Draw()
        {
            foreach (Point p in pList)
            {
                p.Draw();
            }
        }
    }
}
