namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedcosttoeventlistmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventLists", "Cost", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EventLists", "Cost");
        }
    }
}
