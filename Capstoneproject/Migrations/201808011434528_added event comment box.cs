namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedeventcommentbox : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EventComments", "Comment", c => c.String());
            DropColumn("dbo.EventComments", "Post");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EventComments", "Post", c => c.String());
            DropColumn("dbo.EventComments", "Comment");
        }
    }
}
