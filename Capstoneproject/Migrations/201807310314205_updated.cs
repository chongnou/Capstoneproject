namespace Capstoneproject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reserveviptables", "PartySize", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reserveviptables", "PartySize", c => c.Int(nullable: false));
        }
    }
}
