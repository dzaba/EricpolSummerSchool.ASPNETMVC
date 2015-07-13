using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayoffsCreator.Models
{
    public class RoundModel
    {
        public int ID { get; set; }
        private TeamModel[] teams;

        public int RoundTime { get; set; }
        public TeamModel GoalScorer { get; set; }

        public RoundModel(TeamModel[] teams)
        {
            this.teams = teams;
        }

        public void PlayRound()
        {
            Random rand = new Random();
            RoundTime = rand.Next(1, 5);
            GoalScorer = teams[rand.Next(0, 1)];
        }
    }
}