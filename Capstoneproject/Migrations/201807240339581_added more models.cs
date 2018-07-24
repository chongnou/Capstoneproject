namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmoremodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CloseTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserID)
                .Index(t => t.ApplicationUserID);
            
            CreateTable(
                "dbo.EventLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Hours = c.String(),
                        Cost = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OpenTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.AspNetUsers", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "ApplicationUserID" });
            DropColumn("dbo.AspNetUsers", "Role");
            DropTable("dbo.OpenTimes");
            DropTable("dbo.EventLists");
            DropTable("dbo.Customers");
            DropTable("dbo.CloseTimes");
        }
    }
}
