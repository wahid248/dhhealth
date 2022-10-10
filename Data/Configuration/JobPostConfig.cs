using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class JobPostConfig : EntityConfigurationBase<JobPost, int>
    {
        public override void Configure(EntityTypeBuilder<JobPost> builder)
        {
            // write configs here
            builder.HasIndex(j => j.JobCode).IsUnique();
            Seed(builder);
            base.Configure(builder);
        }

        public void Seed(EntityTypeBuilder<JobPost> builder)
        {
        }
    }
}
