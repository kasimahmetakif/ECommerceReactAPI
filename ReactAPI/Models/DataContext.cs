using Microsoft.EntityFrameworkCore;
using ReactAPI.Models;

namespace ReactAPI.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=AHMETAKIF;initial catalog=ReactApiDb2;integrated security=true");
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }
    }
}
