using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    public class Game
    {
        public Player CurrentPlayer { get; set; }
        public List<PlaySquare> Board { get; set; }

        public const int BoardDimension = 3;

        public Game(Player starter)
        {
            CurrentPlayer = starter; 
            Board = Enumerable.Repeat(PlaySquare.N, 9).ToList();
        }


        public void Play(Player player,int x,int y)
        {
            if (x <0 || x >= BoardDimension || y < 0 || y >= BoardDimension || player == CurrentPlayer || Board[x*3+y]!=PlaySquare.N)
                throw new Exception("Not Valid");

            CurrentPlayer = player;
            Board[x * 3 + y] = player==Player.X?PlaySquare.X:PlaySquare.O;

        }

        public PlayResult GetResult()
        { 
            if (Board.Where(w => w == PlaySquare.X || w == PlaySquare.O).Count() < 3)
                return PlayResult.Unknown;

            var combinedWinState = new List<int[]> {
                new [] { 0, 1, 2 }, new [] { 3, 4, 5 }, new [] { 6, 7, 8 },
                new [] { 0, 3, 6 }, new [] { 1, 4, 7 }, new [] { 2, 5, 8 },
                new [] { 0, 4, 8 }, new [] { 2, 4, 6 }
            };

            var result= combinedWinState
                .Where(p =>
                    Board[p[0]] == Board[p[1]] &&
                    Board[p[1]] == Board[p[2]] &&
                    Board[p[0]] != PlaySquare.N)
                .Select(p => Board[p[0]] )
                .FirstOrDefault();

            switch (result)
            { 
                case PlaySquare.X:
                    return PlayResult.WinX;
                case PlaySquare.O:
                    return PlayResult.WinO;
                default:
                    return PlayResult.Unknown;
            }
        }

    }
}
