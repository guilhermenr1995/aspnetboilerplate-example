namespace SoiticTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasefix2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblProviders", "Phone", c => c.String(maxLength: 20));
            AlterColumn("dbo.tblProviders", "CPF", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblProviders", "CPF", c => c.String(maxLength: 14));
            AlterColumn("dbo.tblProviders", "Phone", c => c.String(maxLength: 15));
        }
    }
}
