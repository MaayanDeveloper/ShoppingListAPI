using Microsoft.EntityFrameworkCore;
using ShoppingListAPI.Core.Models;

namespace ShoppingListAPI.Data
{
    public class DataContext :DbContext
    {
        public DbSet<Product> product { get; set; }
        public DbSet<ProductInLIst> ProductIns { get; set; }
        public DbSet<ShopList> ShopLists { get; set; }
        public DbSet<UserO> UserOs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=(localdb)\mssqllocaldb;database=ShoppingListAPI_db");
        }
    }
}
