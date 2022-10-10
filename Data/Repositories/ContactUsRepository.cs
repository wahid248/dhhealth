using Core.Abstruct.Repositories;
using Core.Entities;
using Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    class ContactUsRepository : Repository<ContactUs, int>, IContactUsRepository
    {
        public ContactUsRepository(DataContext dbContext) : base(dbContext) { }
    }
}