using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class PageSectionsConfig : EntityConfigurationBase<PageSections, int>
    {
        public override void Configure(EntityTypeBuilder<PageSections> builder)
        {
            // write configs here
            builder.HasOne(c => c.Page)
                .WithMany(c => c.PageSections)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(c => c.Section)
                .WithMany(c => c.PageSections)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasIndex(c => new { c.PageId, c.SectionId })
                .IsUnique();

            Seed(builder);
            base.Configure(builder);
        }

        public void Seed(EntityTypeBuilder<PageSections> builder)
        {
        }
    }
}
