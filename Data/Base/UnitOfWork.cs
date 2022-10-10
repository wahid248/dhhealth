using Core.Abstruct.Base;
using Core.Abstruct.Repositories;
using Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Data.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DataContext context;
        private bool isDisposed = false;

        public UnitOfWork(DataContext appDbContext)
        {
            context = appDbContext;
        }

        public IImageRepository ImageRepository => new ImageRepository(context);
        public ISectionRepository SectionRepository => new SectionRepository(context);
        public IPageRepository PageRepository => new PageRepository(context);
        public IPageSectionsRepository PageSectionsRepository => new PageSectionsRepository(context);
        public IContactUsRepository ContactUsRepository => new ContactUsRepository(context);
        public ICustomerRepository CustomerRepository => new CustomerRepository(context);
        public IEmailTemplateRepository EmailTemplateRepository => new EmailTemplateRepository(context);
        public IEmailLoggingRepository EmailLoggingRepository => new EmailLoggingRepository(context);
        public IJobPostRepository JobPostRepository => new JobPostRepository(context);
        public INewsRepository NewsRepository => new NewsRepository(context);

        public void Dispose(bool disposing)
        {
            if (!isDisposed) return;
            if (disposing)
            {
                //free managed resources
                this.Dispose();
            }
            //free unmanaged resources
            isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void SaveChanges()
        {
            context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
