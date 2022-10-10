using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public class EmailLogConfig : EntityConfigurationBase<EmailLog, int>
    {
        public override void Configure(EntityTypeBuilder<EmailLog> builder)
        {
            // write configs here
            Seed(builder);
            base.Configure(builder);
        }

        public void Seed(EntityTypeBuilder<EmailLog> builder)
        {
        }
    }
}