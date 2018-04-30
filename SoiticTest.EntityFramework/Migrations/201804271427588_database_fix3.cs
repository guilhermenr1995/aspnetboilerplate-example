namespace SoiticTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database_fix3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblProviders", "Name", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblProviders", "Name", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
