using Core.Abstruct.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Base
{
    public class EntityConfigurationBase<TEntity, T> : IEntityTypeConfiguration<TEntity> where TEntity : class, IEntity<T>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}
