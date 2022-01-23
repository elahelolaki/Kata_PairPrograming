using System;

namespace Manhattan
{
    public class Point
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Point(string coordinate)
        {
            string[] coordinateParts= coordinate.Split(':');
            this.X = int.Parse(coordinateParts[0]);
            this.Y = int.Parse(coordinateParts[1]);
        }
    }
}
