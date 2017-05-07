namespace WebShop.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebShop.DAL.WebShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(WebShop.DAL.WebShopContext context)
        {
            context.Products.AddOrUpdate(x => x.Id,
                new Product() { Id = 1, Name = "Opel", Price = 20000, Stock = 10, IsActive = true },
                new Product() { Id = 2, Name = "Mercedes", Price = 60000, Stock = 25, IsActive = false },
                new Product() { Id = 3, Name = "Audi", Price = 32000, Stock = 18, IsActive = true },
                new Product() { Id = 4, Name = "Fiat", Price = 12000, Stock = 6, IsActive = false },
                new Product() { Id = 5, Name = "Reno", Price = 29000, Stock = 30, IsActive = true }
                );
        }
    }
}
