using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Core.Configuration;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Data;

public class OnlineShopDbContext : IdentityDbContext<AppUser>
{
    public OnlineShopDbContext()
    {
    }

    public OnlineShopDbContext(DbContextOptions<OnlineShopDbContext> options) : base(options)
    {
    }

    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<PaymentDetail> PaymentDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductAttachment> ProductAttachments { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ShoppingSession> ShoppingSessions { get; set; }
    public DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ProductCategoryConfiguration());
        builder.ApplyConfiguration(new DiscountConfiguration());
        builder.ApplyConfiguration(new ProductConfiguration());
        builder.ApplyConfiguration(new WishlistConfiguration());
        builder.ApplyConfiguration(new ShoppingSessionConfiguration());
        builder.ApplyConfiguration(new CartItemConfiguration());
    }
}