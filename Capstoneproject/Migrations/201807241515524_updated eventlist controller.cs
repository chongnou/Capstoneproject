namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedeventlistcontroller : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventLists", "Website", c => c.String());
            DropColumn("dbo.EventLists", "Cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventLists", "Cost", c => c.String());
            DropColumn("dbo.EventLists", "Website");
        }
    }
}
