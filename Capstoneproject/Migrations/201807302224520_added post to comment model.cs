namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedposttocommentmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Post", c => c.String());
            DropColumn("dbo.Comments", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "Email", c => c.String());
            DropColumn("dbo.Comments", "Post");
        }
    }
}
