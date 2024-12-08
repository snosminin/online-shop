using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Model;

namespace OnlineShop.Infrastructure.Configuration;

public class ShoppingSessionConfiguration : IEntityTypeConfiguration<ShoppingSession>
{
    public void Configure(EntityTypeBuilder<ShoppingSession> builder)
    {
        builder.ToTable("shopping_session");

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.UserId).HasColumnName("user_id");

        builder.HasOne(p => p.User).WithMany(m => m.ShoppingSessions).HasForeignKey(k => k.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(m => m.CartItems).WithOne(m => m.ShoppingSession).HasForeignKey(k => k.ShoppingSessionId);
    }
}