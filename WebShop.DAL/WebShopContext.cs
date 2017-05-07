using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.DAL
{
    public class WebShopContext : DbContext
    {
        public WebShopContext() : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .HasPrecision(19, 4);
        }
    }
}