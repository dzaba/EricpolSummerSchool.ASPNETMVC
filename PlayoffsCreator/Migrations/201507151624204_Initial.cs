namespace PlayoffsCreator.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TeamModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PlayerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        TeamModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TeamModels", t => t.TeamModel_ID)
                .Index(t => t.TeamModel_ID);
            
            CreateTable(
                "dbo.RoundModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoundTime = c.Int(nullable: false),
                        GoalScorer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.PlayerModels", new[] { "TeamModel_ID" });
            DropForeignKey("dbo.PlayerModels", "TeamModel_ID", "dbo.TeamModels");
            DropTable("dbo.RoundModels");
            DropTable("dbo.PlayerModels");
            DropTable("dbo.TeamModels");
        }
    }
}
