namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedbarlistrestaurantlisttomodels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventLists", "No", c => c.String());
            DropColumn("dbo.EventLists", "Hours");
            DropColumn("dbo.EventLists", "Cost");
            DropColumn("dbo.EventLists", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventLists", "Address", c => c.String());
            AddColumn("dbo.EventLists", "Cost", c => c.String());
            AddColumn("dbo.EventLists", "Hours", c => c.String());
            DropColumn("dbo.EventLists", "No");
        }
    }
}
