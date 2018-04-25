namespace SoiticTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetime_fix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblProducts", "EntryDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.tblProducts", "ExpirationDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblProducts", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tblProducts", "EntryDate", c => c.DateTime(nullable: false));
        }
    }
}
