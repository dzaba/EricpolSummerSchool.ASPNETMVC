using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayoffsCreator.Models
{
    public class Game
    {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public List<Round> Rounds { get; set; }

        public void PlayGame()
        {
            while (!IsFinished())
            {
                var round = new Round(new Team[] { Team1, Team2 });

                round.PlayRound();

                Rounds.Add(round);
            }
        }

        private bool IsFinished()
        {
            if ((Rounds.Count(o => o.GoalScorer == Team1) >= 10) || (Rounds.Count(o => o.GoalScorer == Team2) >= 10))
                return true;

            return false;
        }
    }
}