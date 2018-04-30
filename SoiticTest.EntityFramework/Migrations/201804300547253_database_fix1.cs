namespace SoiticTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database_fix1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblMovement", "User_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.tblMovement", "User_Id");
            AddForeignKey("dbo.tblMovement", "User_Id", "dbo.AbpUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMovement", "User_Id", "dbo.AbpUsers");
            DropIndex("dbo.tblMovement", new[] { "User_Id" });
            DropColumn("dbo.tblMovement", "User_Id");
        }
    }
}
