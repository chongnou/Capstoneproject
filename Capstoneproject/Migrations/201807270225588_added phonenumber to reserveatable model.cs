namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedphonenumbertoreserveatablemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReserveATables", "EventName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReserveATables", "EventName");
        }
    }
}
