using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Configuration;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.ToTable("cart_item");

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.ProductId).HasColumnName("product_id");
        builder.Property(p => p.ShoppingSessionId).HasColumnName("shopping_session_id");
        builder.Property(p => p.Quantity).HasColumnName("quantity");

        builder.HasOne(p => p.Product).WithMany(m => m.CartItems).HasForeignKey(k => k.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.ShoppingSession).WithMany(m => m.CartItems).HasForeignKey(k => k.ShoppingSessionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}