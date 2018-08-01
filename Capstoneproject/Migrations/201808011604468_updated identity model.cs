namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedidentitymodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Barcomments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BarName = c.String(),
                        Comment = c.String(),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restaurantcomments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RestaurantName = c.String(),
                        Comment = c.String(),
                        PostDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Restaurantcomments");
            DropTable("dbo.Barcomments");
        }
    }
}
