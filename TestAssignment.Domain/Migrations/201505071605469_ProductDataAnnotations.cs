namespace TestAssignment.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDataAnnotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "MinStock", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "MinStock", c => c.String());
        }
    }
}
