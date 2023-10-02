using Microsoft.EntityFrameworkCore;
using ShopHive.API.Models;

namespace ShopHive.API.Data
{
    public class ShopHiveDbContext:DbContext
    {
        public ShopHiveDbContext(DbContextOptions<ShopHiveDbContext> dbContextOptions):base(dbContextOptions)
        {
                
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderReturn> OrderReturns { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Wishlist> Wishlist { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
