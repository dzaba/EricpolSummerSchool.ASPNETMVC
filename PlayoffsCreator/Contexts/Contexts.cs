using System.Data.Entity;

namespace PlayoffsCreator.Models
{
    public class Contexts : DbContext
    {
            public DbSet<TeamModel> Teams { get; set; }

            public DbSet<PlayerModel> PlayerModels { get; set; }

        public Contexts()
        {
            
        }
    }
}