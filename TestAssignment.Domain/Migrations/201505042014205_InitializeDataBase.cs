namespace TestAssignment.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliverPeriod = c.Int(nullable: false),
                        SuplierId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        MinStock = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Supliers", t => t.SuplierId, cascadeDelete: true)
                .Index(t => t.SuplierId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Supliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "SuplierId", "dbo.Supliers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "SuplierId" });
            DropTable("dbo.Users");
            DropTable("dbo.Supliers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
