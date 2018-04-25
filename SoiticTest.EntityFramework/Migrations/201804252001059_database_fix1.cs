namespace SoiticTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database_fix1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblProducts", "ProductId");
            DropColumn("dbo.tblProviders", "ProviderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblProviders", "ProviderId", c => c.Int(nullable: false));
            AddColumn("dbo.tblProducts", "ProductId", c => c.Int(nullable: false));
        }
    }
}
