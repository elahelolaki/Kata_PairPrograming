using System;

namespace MarsRover
{
    public static class Navigate
    {
        static Plateau plateauLimitation;

        public static string Move( string plateau, string currentPosition, string command)
        {
            var plateauParts = plateau.Split(' ');
            plateauLimitation = new Plateau(plateauParts);

            var possitionParts = currentPosition.Split(' ');
            var position= new Position(possitionParts);
            foreach (var cmd in command.ToCharArray())
            {
                if (cmd == 'M')
                    position = Forward(position);
                else if (cmd == 'R')
                    position = RotateRight(position);
                else if (cmd == 'L')
                    position = RotateLeft(position);
            } 
            return position.ShowLoction();
        }

        public static Position Forward(Position position)
        {
            switch (position.Direction)
            {
                case Direction.N:
                    position.Y++;
                    break;
                case Direction.E:
                    position.X++;
                    break;
                case Direction.S:
                    position.Y--;
                    break;
                case Direction.W:
                    position.X--;
                    break;
                default:
                    break;
            } 

            if (position.Y > plateauLimitation.MaxY)
                position.Y = 0;
            if (position.X > plateauLimitation.MaxX)
                position.X = 0;
            return position;
        }

        public static Position RotateRight(Position position)
        {
            position.Direction = (position.Direction + 1 > Direction.W) ? Direction.N : position.Direction + 1;
            return position;

        }

        public static Position RotateLeft(Position position)
        {
            position.Direction = (position.Direction - 1 < Direction.N) ? Direction.W : position.Direction - 1;
            return position;

        }
    }
}
