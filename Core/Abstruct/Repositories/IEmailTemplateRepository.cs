using Core.Abstruct.Base;
using Core.Dtos;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstruct.Repositories
{
    public interface IEmailTemplateRepository : IRepository<EmailTemplate,int>
    {
        Task<EmailTemplateDto> GetTemplate(int templateId);
    }
}
