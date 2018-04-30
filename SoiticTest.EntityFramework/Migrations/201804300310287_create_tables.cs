namespace SoiticTest.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class create_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblMovement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PreviousQtd = c.Int(nullable: false),
                        CurrentQtd = c.Int(nullable: false),
                        Signal = c.String(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Product_Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Movement_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblProducts", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Description = c.String(maxLength: 300),
                        Brand = c.String(maxLength: 60),
                        EntryDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(nullable: false),
                        Value = c.Decimal(nullable: false, storeType: "money"),
                        Stock = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Product_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Address = c.String(maxLength: 300),
                        Phone = c.String(maxLength: 20),
                        CPF = c.String(maxLength: 20),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Provider_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProviderProducts",
                c => new
                    {
                        Provider_Id = c.Int(nullable: false),
                        Product_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider_Id, t.Product_Id })
                .ForeignKey("dbo.tblProviders", t => t.Provider_Id, cascadeDelete: true)
                .ForeignKey("dbo.tblProducts", t => t.Product_Id, cascadeDelete: true)
                .Index(t => t.Provider_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblMovement", "Product_Id", "dbo.tblProducts");
            DropForeignKey("dbo.ProviderProducts", "Product_Id", "dbo.tblProducts");
            DropForeignKey("dbo.ProviderProducts", "Provider_Id", "dbo.tblProviders");
            DropIndex("dbo.ProviderProducts", new[] { "Product_Id" });
            DropIndex("dbo.ProviderProducts", new[] { "Provider_Id" });
            DropIndex("dbo.tblMovement", new[] { "Product_Id" });
            DropTable("dbo.ProviderProducts");
            DropTable("dbo.tblProviders",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Provider_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.tblProducts",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Product_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.tblMovement",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Movement_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
