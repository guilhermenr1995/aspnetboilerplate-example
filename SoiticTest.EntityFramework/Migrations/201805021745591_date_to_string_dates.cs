namespace SoiticTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date_to_string_dates : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tblProducts", "EntryDate", c => c.String(nullable: false));
            AlterColumn("dbo.tblProducts", "ExpirationDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tblProducts", "ExpirationDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tblProducts", "EntryDate", c => c.DateTime(nullable: false));
        }
    }
}
