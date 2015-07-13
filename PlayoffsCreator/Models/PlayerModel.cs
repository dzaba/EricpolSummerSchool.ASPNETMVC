using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PlayoffsCreator.Models
{
    public class PlayerModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public class PlayerDBContext : DbContext
        {
            public DbSet<PlayerModel> Players { get; set; }
        }
    }
}