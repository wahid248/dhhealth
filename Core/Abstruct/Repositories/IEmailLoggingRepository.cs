using Core.Abstruct.Base;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Abstruct.Repositories
{
    public interface IEmailLoggingRepository : IRepository<EmailLog, int>
    {
    }
}
