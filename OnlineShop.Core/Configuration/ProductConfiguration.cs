using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Model;

namespace OnlineShop.Core.Configuration;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("product");

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Description).HasColumnName("description");
        builder.Property(p => p.DiscountId).HasColumnName("discount_id");
        builder.Property(p => p.Price).HasColumnName("price");
        builder.Property(p => p.Quantity).HasColumnName("quantity");
        builder.Property(p => p.Sku).HasColumnName("sku");
        builder.Property(p => p.ProductCategoryId).HasColumnName("product_category_id");

        builder.HasOne(p => p.Discount).WithMany(m => m.Products).HasForeignKey(k => k.DiscountId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.ProductCategory).WithMany(m => m.Products).HasForeignKey(k => k.ProductCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}