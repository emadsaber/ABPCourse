using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace ABPCourse.Demo1.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ConfigureByConvention();

            builder.Property(x => x.NameAr).HasMaxLength(Demo1Consts.GeneralTextMaxLength).IsRequired();
            builder.Property(x => x.NameEn).HasMaxLength(Demo1Consts.GeneralTextMaxLength).IsRequired();
            builder.Property(x => x.DescriptionAr).HasMaxLength(Demo1Consts.DescriptionTextMaxLength).IsRequired();
            builder.Property(x => x.DescriptionEn).HasMaxLength(Demo1Consts.DescriptionTextMaxLength).IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany()
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();

            builder.ToTable("Products");
        }
    }
}
