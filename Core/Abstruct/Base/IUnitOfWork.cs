using Core.Abstruct.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstruct.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
        Task SaveChangesAsync();


        IImageRepository ImageRepository { get; }
        ISectionRepository SectionRepository { get; }
        IPageRepository PageRepository { get; }
        IPageSectionsRepository PageSectionsRepository { get; }
        IContactUsRepository ContactUsRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IEmailTemplateRepository EmailTemplateRepository { get; }
        IEmailLoggingRepository EmailLoggingRepository { get; }
        IJobPostRepository JobPostRepository { get; }
        INewsRepository NewsRepository { get; }
    }
}
