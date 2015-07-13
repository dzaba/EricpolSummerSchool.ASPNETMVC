using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PlayoffsCreator.Models.Context
{
    public class GamesDBContext : DbContext
    {
        public DbSet<GameModel> Games { get; set; }
        public DbSet<RoundModel> Rounds { get; set; }
        public DbSet<TeamModel> Teams { get; set; }

        
    }
}