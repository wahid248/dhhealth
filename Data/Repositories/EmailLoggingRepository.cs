using Core.Abstruct.Repositories;
using Core.Entities;
using Data.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class EmailLoggingRepository : Repository<EmailLog, int>, IEmailLoggingRepository
    {
        public EmailLoggingRepository(DataContext dbContext) : base(dbContext) { }

    }
}
 
