using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Core.Model;

namespace OnlineShop.Infrastructure.Configuration;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("discount");

        builder.Property(p => p.Id).HasColumnName("id");
        builder.Property(p => p.Name).HasColumnName("name");
        builder.Property(p => p.Description).HasColumnName("description");
        builder.Property(p => p.Value).HasColumnName("value");

        //builder.HasOne(p => p.Discount).WithMany(m => m.Products).HasForeignKey(k => k.DiscountId);
        //builder.HasOne(p => p.ProductCategory).WithMany(m => m.Products).HasForeignKey(k => k.ProductCategoryId);
        builder.HasMany(m => m.Products).WithOne(m => m.Discount).HasForeignKey(k => k.DiscountId);
        // builder.HasMany(m => m.Departments).WithOne(m => m.Company).HasForeignKey(k => k.CompanyId);
    }
}