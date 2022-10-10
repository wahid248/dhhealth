using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class PageConfig : EntityConfigurationBase<Page, int>
    {
        public override void Configure(EntityTypeBuilder<Page> builder)
        {
            // write configs here
            builder.HasMany(c => c.PageSections)
                .WithOne(c => c.Page)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            builder.HasOne(c => c.Banner)
                .WithMany(c => c.PageBaners)
                .IsRequired(false)
                .HasForeignKey(c => c.BannerId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
            builder.Property(c => c.ControllerName).HasMaxLength(50).IsRequired();
            builder.Property(c => c.ActionName).HasMaxLength(50);

            Seed(builder);
            base.Configure(builder);
        }

        public void Seed(EntityTypeBuilder<Page> builder)
        {
            var createdOn = DateTime.UtcNow;

            builder.HasData(
                new Page() { Id = 1, Name = "Home", ControllerName = "Home", IsEnabled = true, CreatedBy = "SYSTEM", CreatedOn = createdOn },
                new Page() { Id = 2, Name = "Who We Are", ControllerName = "WhoWeAre", IsEnabled = true, CreatedBy = "SYSTEM", CreatedOn = createdOn },
                new Page() { Id = 3, Name = "Our Services", ControllerName = "OurServices", IsEnabled = true, CreatedBy = "SYSTEM", CreatedOn = createdOn },
                new Page() { Id = 4, Name = "Sustainable Impacts", ControllerName = "SustainableImpacts", IsEnabled = true, CreatedBy = "SYSTEM", CreatedOn = createdOn },
                new Page() { Id = 5, Name = "Partner With Us", ControllerName = "PartnerWithUs", IsEnabled = true, CreatedBy = "SYSTEM", CreatedOn = createdOn },
                new Page() { Id = 6, Name = "Our Brands", ControllerName = "OurBrands", IsEnabled = true, CreatedBy = "SYSTEM", CreatedOn = createdOn },
                new Page() { Id = 7, Name = "Career", ControllerName = "Career", IsEnabled = true, CreatedBy = "SYSTEM", CreatedOn = createdOn },
                new Page() { Id = 8, Name = "News", ControllerName = "News", IsEnabled = true, CreatedBy = "SYSTEM", CreatedOn = createdOn },
                new Page() { Id = 9, Name = "Contact Us", ControllerName = "ContactUs", IsEnabled = true, CreatedBy = "SYSTEM", CreatedOn = createdOn });
        }
    }
}
