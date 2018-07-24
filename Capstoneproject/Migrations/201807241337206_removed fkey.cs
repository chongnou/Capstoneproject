namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedfkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Admins", new[] { "ApplicationUserID" });
            DropColumn("dbo.Admins", "ApplicationUserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "ApplicationUserID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Admins", "ApplicationUserID");
            AddForeignKey("dbo.Admins", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
    }
}
