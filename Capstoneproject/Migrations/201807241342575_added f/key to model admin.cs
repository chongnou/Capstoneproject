namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfkeytomodeladmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Admins", "ApplicationUserID");
            AddForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Admins", new[] { "ApplicationUserID" });
            DropColumn("dbo.Admins", "ApplicationUserID");
        }
    }
}
