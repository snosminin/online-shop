using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Configuration;

public class WishlistConfiguration : IEntityTypeConfiguration<Wishlist>
{
    public void Configure(EntityTypeBuilder<Wishlist> builder)
    {
        builder.ToTable("wishlist");

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.UserId).HasColumnName("user_id");
        builder.Property(p => p.ProductId).HasColumnName("product_id");

        builder.HasOne(p => p.User).WithMany(m => m.Wishlists).HasForeignKey(k => k.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.Product).WithMany(m => m.Wishlists).HasForeignKey(k => k.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}