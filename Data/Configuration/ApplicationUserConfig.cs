using Core.Entities.Identity;
using Data.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class ApplicationUserConfig : EntityConfigurationBase<ApplicationUser, string>
    {
        public override void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            // write configs here
            builder.HasMany(c => c.Sections)
                .WithOne(c => c.User)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            builder.HasMany(c => c.Images)
                .WithOne(c => c.User)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            base.Configure(builder);
        }
    }
}
