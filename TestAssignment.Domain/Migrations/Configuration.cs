using TestAssignment.Domain.Models.DomainModels;

namespace TestAssignment.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TestAssignment.Domain.Context.DataBaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestAssignment.Domain.Context.DataBaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            context.Categories.AddOrUpdate(
                x=>x.Name,
                new Category() { Name = "Fruits"},
                new Category() { Name = "Drinks"},
                new Category() { Name = "Vegetables"},
                new Category() { Name = "Meat"}
                );
            context.SaveChanges();
            context.Supliers.AddOrUpdate(
                x=>x.Name,
                new Suplier() { Name = "Suplier 1"},
                  new Suplier() { Name = "Suplier 2"},
                  new Suplier() { Name = "Suplier 3"}
                );
            context.SaveChanges();
            context.Products.AddOrUpdate(
                x => x.ProductName,
                new Product()
                {
                    CategoryId = 1,
                    DeliverPeriod = 10,
                    MinStock = "32",
                    Price = 2,
                    ProductName = "Apple",
                    SuplierId = 1
                },
                new Product()
                {
                    CategoryId = 2,
                    DeliverPeriod = 2,
                    MinStock = "54",
                    Price = 2,
                    ProductName = "Coca-Cola",
                    SuplierId = 2
                },
                new Product()
                {
                    CategoryId = 3,
                    DeliverPeriod = 21,
                    MinStock = "10",
                    Price = 2,
                    ProductName = "Carrot",
                    SuplierId = 3
                },
                new Product()
                {
                    CategoryId = 4,
                    DeliverPeriod = 32,
                    MinStock = "54",
                    Price = 2,
                    ProductName = "Chicken",
                    SuplierId = 1
                },
                new Product()
                {
                    CategoryId = 1,
                    DeliverPeriod = 12,
                    MinStock = "23",
                    Price = 2,
                    ProductName = "Strawberry",
                    SuplierId = 2
                },
                new Product()
                {
                    CategoryId = 2,
                    DeliverPeriod = 32,
                    MinStock = "32",
                    Price = 2,
                    ProductName = "Pepsi",
                    SuplierId = 3
                },
                new Product()
                {
                    CategoryId = 3,
                    DeliverPeriod = 11,
                    MinStock = "12",
                    Price = 2,
                    ProductName = "Tomato",
                    SuplierId = 1
                });
            context.SaveChanges();
        }
    }
}
