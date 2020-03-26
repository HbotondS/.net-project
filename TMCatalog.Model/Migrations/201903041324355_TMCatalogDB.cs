namespace TMCatalog.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TMCatalogDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleNumber = c.String(),
                        Description = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ProductGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductGroups", t => t.ProductGroupId, cascadeDelete: true)
                .Index(t => t.ProductGroupId);
            
            CreateTable(
                "dbo.ProductGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FuelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Article_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Articles", t => t.Article_Id)
                .Index(t => t.Article_Id);
            
            CreateTable(
                "dbo.VehicleTypeArticles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false),
                        VehicleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ArticleId, t.VehicleTypeId })
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.ArticleId)
                .Index(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ModelId = c.Int(nullable: false),
                        TecDocID = c.Int(nullable: false),
                        ProductionYearFrom = c.Int(nullable: false),
                        ProductionYearTo = c.Int(nullable: false),
                        FuelTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FuelTypes", t => t.FuelTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId)
                .Index(t => t.FuelTypeId);
            
            CreateTable(
                "dbo.VehicleTypePlateNrs",
                c => new
                    {
                        PlateNr = c.String(nullable: false, maxLength: 128),
                        VehicleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlateNr)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.VehicleTypeProducts",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        VehicleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductId, t.VehicleTypeId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.VehicleTypeVins",
                c => new
                    {
                        VIN = c.String(nullable: false, maxLength: 128),
                        VehicleTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VIN)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.VehicleTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleTypeVins", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleTypeProducts", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleTypeProducts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.VehicleTypePlateNrs", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleTypeArticles", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleTypes", "ModelId", "dbo.Models");
            DropForeignKey("dbo.VehicleTypes", "FuelTypeId", "dbo.FuelTypes");
            DropForeignKey("dbo.VehicleTypeArticles", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Stocks", "Article_Id", "dbo.Articles");
            DropForeignKey("dbo.Models", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Articles", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductGroupId", "dbo.ProductGroups");
            DropIndex("dbo.VehicleTypeVins", new[] { "VehicleTypeId" });
            DropIndex("dbo.VehicleTypeProducts", new[] { "VehicleTypeId" });
            DropIndex("dbo.VehicleTypeProducts", new[] { "ProductId" });
            DropIndex("dbo.VehicleTypePlateNrs", new[] { "VehicleTypeId" });
            DropIndex("dbo.VehicleTypes", new[] { "FuelTypeId" });
            DropIndex("dbo.VehicleTypes", new[] { "ModelId" });
            DropIndex("dbo.VehicleTypeArticles", new[] { "VehicleTypeId" });
            DropIndex("dbo.VehicleTypeArticles", new[] { "ArticleId" });
            DropIndex("dbo.Stocks", new[] { "Article_Id" });
            DropIndex("dbo.Models", new[] { "ManufacturerId" });
            DropIndex("dbo.Products", new[] { "ProductGroupId" });
            DropIndex("dbo.Articles", new[] { "ProductId" });
            DropTable("dbo.VehicleTypeVins");
            DropTable("dbo.VehicleTypeProducts");
            DropTable("dbo.VehicleTypePlateNrs");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.VehicleTypeArticles");
            DropTable("dbo.Stocks");
            DropTable("dbo.Models");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.FuelTypes");
            DropTable("dbo.ProductGroups");
            DropTable("dbo.Products");
            DropTable("dbo.Articles");
        }
    }
}
