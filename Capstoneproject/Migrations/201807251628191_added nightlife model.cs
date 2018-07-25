namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednightlifemodel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BarLists", newName: "NightLives");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.NightLives", newName: "BarLists");
        }
    }
}
