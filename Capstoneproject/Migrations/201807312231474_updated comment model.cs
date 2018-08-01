namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedcommentmodel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Comments", newName: "EventComments");
            DropColumn("dbo.EventComments", "RestaurantName");
            DropColumn("dbo.EventComments", "BarName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventComments", "BarName", c => c.String());
            AddColumn("dbo.EventComments", "RestaurantName", c => c.String());
            RenameTable(name: "dbo.EventComments", newName: "Comments");
        }
    }
}
