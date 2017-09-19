namespace ChurrasTrinca.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initializer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barbecue",
                c => new
                    {
                        BarbecueID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Description = c.String(nullable: false, maxLength: 200),
                        Comments = c.String(maxLength: 500),
                        WithDrink = c.Decimal(nullable: false, precision: 5, scale: 2),
                        WithoutDrink = c.Decimal(nullable: false, precision: 5, scale: 2),
                    })
                .PrimaryKey(t => t.BarbecueID);
            
            CreateTable(
                "dbo.Participant",
                c => new
                    {
                        ParticipantID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ContributionValue = c.Decimal(nullable: false, precision: 5, scale: 2),
                        IsPaid = c.Boolean(nullable: false),
                        WithDrink = c.Boolean(nullable: false),
                        Comments = c.String(maxLength: 200),
                        Barbecue_BarbecueID = c.Int(),
                    })
                .PrimaryKey(t => t.ParticipantID)
                .ForeignKey("dbo.Barbecue", t => t.Barbecue_BarbecueID)
                .Index(t => t.Barbecue_BarbecueID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participant", "Barbecue_BarbecueID", "dbo.Barbecue");
            DropIndex("dbo.Participant", new[] { "Barbecue_BarbecueID" });
            DropTable("dbo.Participant");
            DropTable("dbo.Barbecue");
        }
    }
}
