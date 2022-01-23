using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Plateau
    {
        public int MaxX { get; set; }

        public int MaxY { get; set; }

        public Plateau(string[] arr)
        {
            this.MaxX = int.Parse(arr[0]);
            this.MaxY = int.Parse(arr[1]);
        }
    }
}
