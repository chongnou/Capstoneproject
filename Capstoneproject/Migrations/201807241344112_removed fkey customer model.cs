namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedfkeycustomermodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "ApplicationUserID" });
            AddColumn("dbo.Admins", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Admins", "ApplicationUserID");
            AddForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Customers", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ApplicationUserID", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Admins", new[] { "ApplicationUserID" });
            DropColumn("dbo.Admins", "ApplicationUserID");
            CreateIndex("dbo.Customers", "ApplicationUserID");
            AddForeignKey("dbo.Customers", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
    }
}
