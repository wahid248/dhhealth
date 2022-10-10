using Core.Abstruct.Repositories;
using Core.Dtos;
using Core.Entities;
using Data.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EmailTemplateRepository : Repository<EmailTemplate, int>, IEmailTemplateRepository
    {
        public EmailTemplateRepository(DataContext dbContext) : base(dbContext) { }

        public async Task<EmailTemplateDto> GetTemplate(int templateId)
        {
            return await _dbSet.Where(s => s.Id == templateId)
                .Select(s => new EmailTemplateDto()
                {
                    Id = s.Id,
                    TemplateType = s.TemplateType,
                    TemplateName = s.TemplateName,
                    Body = s.Body
                }).FirstOrDefaultAsync();
        }
    }
}
