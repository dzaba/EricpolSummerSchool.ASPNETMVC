using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayoffsCreator.Models
{
    public class GameModel
    {
        public int ID { get; set; }
        public TeamModel Team1 { get; set; }
        public TeamModel Team2 { get; set; }
        public List<RoundModel> Rounds { get; set; }

        public void PlayGame()
        {
            while (!IsFinished())
            {
                var round = new RoundModel(new TeamModel[] { Team1, Team2 });

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