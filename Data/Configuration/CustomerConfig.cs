using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class CustomerConfig : EntityConfigurationBase<Customer, int>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            // write configs here
            Seed(builder);
            base.Configure(builder);
        }

        public void Seed(EntityTypeBuilder<Customer> builder)
        {
        }
    }
}