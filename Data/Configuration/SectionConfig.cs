using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class SectionConfig : EntityConfigurationBase<Section, int>
    {
        public override void Configure(EntityTypeBuilder<Section> builder)
        {
            // write configs here
            builder.HasOne(c => c.Image)
                .WithMany(c => c.Sections)
                .HasForeignKey(c => c.ImageId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            builder.HasOne(c => c.User)
                .WithMany(c => c.Sections)
                .HasForeignKey(c => c.CreatedBy)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(c => c.ParentSection)
                .WithMany()
                .HasForeignKey(c => c.ParentSectionId);
            builder.HasMany(c => c.PageSections)
                .WithOne(c => c.Section)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            //set max length for title
            builder.Property(c => c.TitleLarge).HasMaxLength(500);
            builder.Property(c => c.TitleSmall).HasMaxLength(200);

            Seed(builder);
            base.Configure(builder);
        }

        public void Seed(EntityTypeBuilder<Section> builder)
        {

        }
    }
}
