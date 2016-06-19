namespace Sparker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ClockIn = c.DateTime(nullable: false),
                        EventDetailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EventDetails", t => t.EventDetailId, cascadeDelete: true)
                .Index(t => t.EventDetailId);
            
            CreateTable(
                "dbo.EventDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        EventId = c.Int(nullable: false),
                        UniversityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Universities", t => t.UniversityId, cascadeDelete: true)
                .Index(t => t.EventId)
                .Index(t => t.UniversityId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MspId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Msps", t => t.MspId, cascadeDelete: true)
                .Index(t => t.MspId);
            
            CreateTable(
                "dbo.Msps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Role = c.Int(nullable: false),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventDetails", "UniversityId", "dbo.Universities");
            DropForeignKey("dbo.Msps", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.Events", "MspId", "dbo.Msps");
            DropForeignKey("dbo.EventDetails", "EventId", "dbo.Events");
            DropForeignKey("dbo.Attendees", "EventDetailId", "dbo.EventDetails");
            DropIndex("dbo.Msps", new[] { "RegionId" });
            DropIndex("dbo.Events", new[] { "MspId" });
            DropIndex("dbo.EventDetails", new[] { "UniversityId" });
            DropIndex("dbo.EventDetails", new[] { "EventId" });
            DropIndex("dbo.Attendees", new[] { "EventDetailId" });
            DropTable("dbo.Universities");
            DropTable("dbo.Regions");
            DropTable("dbo.Msps");
            DropTable("dbo.Events");
            DropTable("dbo.EventDetails");
            DropTable("dbo.Attendees");
        }
    }
}
