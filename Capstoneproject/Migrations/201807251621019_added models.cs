namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedmodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BarLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        Name = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RestaurantLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        No = c.String(),
                        Name = c.String(),
                        Website = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RestaurantLists");
            DropTable("dbo.BarLists");
        }
    }
}
