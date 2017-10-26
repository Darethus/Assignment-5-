namespace Assignment_5.Migrations
{
    using Assignment_5.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Assignment_5.DataAccess.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Assignment_5.DataAccess.StoreContext context)
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

            context.Items.AddOrUpdate(
                i => i.ArticleNumber,
                new StockItem { ArticleNumber = 1, Name="Item1", Price=22, ShelfPosition="Lower shelf", Quantity= 5, Description="Smooth"},
                new StockItem { ArticleNumber = 2, Name="Item2", Price=22, ShelfPosition="Middle shelf", Quantity= 5, Description="Coarse"},
                new StockItem { ArticleNumber = 3, Name="Item3", Price=22, ShelfPosition="Upper shelf", Quantity= 5, Description="Soft"},
                new StockItem { ArticleNumber = 4, Name="Item4", Price=22, ShelfPosition="Top shelf", Quantity= 5, Description="Hard"}

                );
        }
    }
}
