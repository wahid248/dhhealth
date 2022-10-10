using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class ImageConfig : EntityConfigurationBase<Image, int>
    {
        public override void Configure(EntityTypeBuilder<Image> builder)
        {
            // write configs here
            builder.HasMany(c => c.Sections)
                .WithOne(c => c.Image)
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(c => c.User)
                .WithMany(c => c.Images)
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.Property(c => c.ImageUrl).HasMaxLength(1000);
            builder.Property(c => c.BottomText).HasMaxLength(300);

            Seed(builder);
            base.Configure(builder);
        }

        public void Seed(EntityTypeBuilder<Image> builder)
        {
        }
    }
}
