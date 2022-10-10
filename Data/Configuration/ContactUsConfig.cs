using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class ContactUsConfig : EntityConfigurationBase<ContactUs, int>
    {
        public override void Configure(EntityTypeBuilder<ContactUs> builder)
        {
            // write configs here
            builder.HasOne(c => c.Customer)
                .WithMany()
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            Seed(builder);
            base.Configure(builder);
        }

        public void Seed(EntityTypeBuilder<ContactUs> builder)
        {
        }
    }
}

