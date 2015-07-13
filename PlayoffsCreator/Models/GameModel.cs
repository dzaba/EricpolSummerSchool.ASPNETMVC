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

        public IDictionary<int, int> Result()
        {
            IDictionary<int, int> result = new Dictionary<int, int>();
            int score1 = Rounds.Count(o => o.GoalScorer == Team1);
            result.Add(Team1.ID,score1);

            int score2 = Rounds.Count(o => o.GoalScorer == Team2);
            result.Add(Team2.ID, score2);

            return result;

        }

        private bool IsFinished()
        {
            if ((Rounds.Count(o => o.GoalScorer == Team1) >= 10) || (Rounds.Count(o => o.GoalScorer == Team2) >= 10))
                return true;

            return false;
        }
    }
}