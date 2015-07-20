namespace PlayoffsCreator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodaniegamecontexstu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TreeLevel = c.Int(nullable: false),
                        Team1_ID = c.Int(),
                        Team2_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TeamModels", t => t.Team1_ID)
                .ForeignKey("dbo.TeamModels", t => t.Team2_ID)
                .Index(t => t.Team1_ID)
                .Index(t => t.Team2_ID);
            
            AddColumn("dbo.RoundModels", "GameModel_ID", c => c.Int());
            AddForeignKey("dbo.RoundModels", "GameModel_ID", "dbo.GameModels", "ID");
            CreateIndex("dbo.RoundModels", "GameModel_ID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.GameModels", new[] { "Team2_ID" });
            DropIndex("dbo.GameModels", new[] { "Team1_ID" });
            DropIndex("dbo.RoundModels", new[] { "GameModel_ID" });
            DropForeignKey("dbo.GameModels", "Team2_ID", "dbo.TeamModels");
            DropForeignKey("dbo.GameModels", "Team1_ID", "dbo.TeamModels");
            DropForeignKey("dbo.RoundModels", "GameModel_ID", "dbo.GameModels");
            DropColumn("dbo.RoundModels", "GameModel_ID");
            DropTable("dbo.GameModels");
        }
    }
}
