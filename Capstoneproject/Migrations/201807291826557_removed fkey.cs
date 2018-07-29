namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedfkey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Registerforeventmodels", "ApplicationUserID", "dbo.AspNetUsers");
            DropIndex("dbo.Registerforeventmodels", new[] { "ApplicationUserID" });
            CreateTable(
                "dbo.Registerforevents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EventName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Registerforeventmodels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Registerforeventmodels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EventName = c.String(),
                        Email = c.String(),
                        ApplicationUserID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Registerforevents");
            CreateIndex("dbo.Registerforeventmodels", "ApplicationUserID");
            AddForeignKey("dbo.Registerforeventmodels", "ApplicationUserID", "dbo.AspNetUsers", "Id");
        }
    }
}
