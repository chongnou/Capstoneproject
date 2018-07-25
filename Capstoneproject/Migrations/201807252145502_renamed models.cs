namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renamedmodels : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventLists", newName: "Activities");
            RenameTable(name: "dbo.RestaurantLists", newName: "Restaurants");
            DropTable("dbo.CloseTimes");
            DropTable("dbo.OpenTimes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OpenTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CloseTimes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Start = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            RenameTable(name: "dbo.Restaurants", newName: "RestaurantLists");
            RenameTable(name: "dbo.Activities", newName: "EventLists");
        }
    }
}
