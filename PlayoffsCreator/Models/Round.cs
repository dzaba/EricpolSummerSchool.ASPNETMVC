using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayoffsCreator.Models
{
    public class Round
    {
        public int ID { get; set; }
        private Team[] teams;

        public int RoundTime { get; set; }
        public Team GoalScorer { get; set; }

        public Round(Team[] teams)
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