namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedeventnametoeventlistmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterForEvents", "EventName", c => c.String());
            DropColumn("dbo.RegisterForEvents", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisterForEvents", "PhoneNumber", c => c.String());
            DropColumn("dbo.RegisterForEvents", "EventName");
        }
    }
}
