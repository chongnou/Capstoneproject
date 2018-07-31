namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedmodels : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Activities", "Website");
            DropColumn("dbo.NightLives", "Website");
            DropColumn("dbo.Restaurants", "Website");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "Website", c => c.String());
            AddColumn("dbo.NightLives", "Website", c => c.String());
            AddColumn("dbo.Activities", "Website", c => c.String());
        }
    }
}
