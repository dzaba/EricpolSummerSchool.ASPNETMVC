using System.Data.Entity;

namespace PlayoffsCreator.Models
{
    public class Contexts : DbContext
    {
        public DbSet<TeamModel> Teams { get; set; }

        public DbSet<PlayerModel> PlayerModels { get; set; }

        public DbSet<RoundModel> RoundModels { get; set; }

        public DbSet<GameModel> GameModels { get; set; }

        public Contexts()
        {

        }

    }

}