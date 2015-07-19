using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlayoffsCreator.Models
{
    public class TeamModel
    {
        public int ID { get; set; }
        public String TeamName { get; set; }
        public List<PlayerModel> players { get; set; }

        public TeamModel()
        {
            players = new List<PlayerModel>(); 
        }
    }
}