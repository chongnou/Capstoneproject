namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NightLives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        Name = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        Name = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.EventLists", "No", c => c.String());
            AddColumn("dbo.EventLists", "Website", c => c.String());
            DropColumn("dbo.EventLists", "Hours");
            DropColumn("dbo.EventLists", "Cost");
            DropColumn("dbo.EventLists", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventLists", "Address", c => c.String());
            AddColumn("dbo.EventLists", "Cost", c => c.String());
            AddColumn("dbo.EventLists", "Hours", c => c.String());
            DropColumn("dbo.EventLists", "Website");
            DropColumn("dbo.EventLists", "No");
            DropTable("dbo.RestaurantLists");
            DropTable("dbo.NightLives");
        }
    }
}
