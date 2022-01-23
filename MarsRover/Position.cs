using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class Position
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Direction Direction { get; set; }

        public Position(string[] arr)
        {
            this.X = int.Parse(arr[0]);
            this.Y = int.Parse(arr[1]); 
            this.Direction = (Direction)Enum.Parse(typeof(Direction), arr[2]);
        }

        public string ShowLoction()
        {
            return $"{this.X} {this.Y} {this.Direction}";
        }
    }
}
