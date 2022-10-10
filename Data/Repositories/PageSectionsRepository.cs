using Core.Abstruct.Repositories;
using Core.Entities;
using Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class PageSectionsRepository : Repository<PageSections, int>, IPageSectionsRepository
    {
        public PageSectionsRepository(DataContext dbContext) : base(dbContext) { }
    }
}
