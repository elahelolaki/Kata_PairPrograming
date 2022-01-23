using System;
using System.Collections.Generic;
using System.Text;

namespace Manhattan
{
    public class Grid
    {
        public List<Point> Points { get; set; }

        public Grid(string[] coordinates)
        {
            Points = new List<Point>();
            foreach (var coordinate in coordinates)
            {
                Points.Add(new Point(coordinate));
            }
        }

        public int ManhattanDistance(Point p1,Point p2)
        {
            var dis1 = p2.X - p1.X;
            var dis2 = p2.Y - p1.Y;
            return Math.Abs(dis1) + Math.Abs(dis2); 
        }
    }
}
