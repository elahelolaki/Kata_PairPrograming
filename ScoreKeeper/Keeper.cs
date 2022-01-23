using System;
using System.Collections.Generic;
using System.Text;

namespace ScoreKeeper
{
    public class Keeper
    {
        public List<int> Scores { get; set; }
        public Keeper(int initalA,int initialB)
        {
            Scores = new List<int> { initalA, initialB };
        }

        public void ScoreTeamA1() => AddTo(Team.A, 1);
        public void ScoreTeamB1() => AddTo(Team.B, 1);
        public void ScoreTeamA2() => AddTo(Team.A, 2);
        public void ScoreTeamB2() => AddTo(Team.B, 2);
        public void ScoreTeamA3() => AddTo(Team.A, 3);
        public void ScoreTeamB3() => AddTo(Team.B, 3);

        public void AddTo(Team team,int value)
        {
            if (value < 0 || value > 999)
                throw new Exception("Score cannot be over 999 points.");

            Scores[(int)team] = value;
        }

        public string Show()
        {
            return $"{Scores[(int)Team.A]:D3}:{Scores[(int)Team.B]:D3}";
        }
    }
}
